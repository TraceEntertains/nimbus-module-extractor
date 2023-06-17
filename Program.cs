using System.Reflection;

namespace ThreeDSModuleExtractor
{
    public class Program
    {
        public static List<string> Errors = new();
        public static Dictionary<string, string> Modules = new()
        {
            { "act", "0004013000003802" },
            { "friends", "0004013000003202" },
            { "juxt", "000400300000Bx02" }, // proper region handling later in code
            { "ssl", "0004013000002F02" }
        };
        public static List<string> MissingModules = new();

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Errors.Add("Your copy of nimbus has not been dragged and dropped on this executable, please do so when executing.");
            }
            else
            {
                if (!Directory.Exists(Path.Combine(args[0], "patches")))
                {
                    Errors.Add("This is not a valid nimbus installation.");
                }
                else
                {
                    foreach (KeyValuePair<string, string> module in Modules)
                    {
                        if (!Directory.Exists(Path.Combine(args[0], "patches", module.Key)))
                        {
                            MissingModules.Add(module.Key);
                        }
                    }

                    if (MissingModules.Count == 1)
                    {
                        Errors.Add($"Missing module folder in nimbus: {MissingModules[0]}");
                    }
                    else if (MissingModules.Count > 1)
                    {
                        Errors.Add($"Missing module folders in nimbus: {string.Join(", ", MissingModules)}");
                    }
                }
            }

            bool patchfolderfound = false;
            bool threedsfolderfound = false;
            char driveletter = 'C';
            char juxtregion = 'D';
            foreach (string drive in Directory.GetLogicalDrives())
            {
                if (Directory.Exists(Path.Combine(drive, "nimbusmodules")))
                {
                    patchfolderfound = true;
                }
                if (Directory.Exists(Path.Combine(drive, "Nintendo 3DS")))
                {
                    threedsfolderfound = true;
                }

                if (threedsfolderfound)
                {
                    driveletter = drive[0];
                    break;
                }
            }


            if (!patchfolderfound && !threedsfolderfound)
            {
                Errors.Add("Please insert your 3DS SD card after running the script if you haven't already.");
            }
            else if (!patchfolderfound && threedsfolderfound)
            {
                Errors.Add("Please run the script on your 3DS before re-inserting the SD card.");
            }

            if (Errors.Count == 0)
            {
                foreach (string folder in Directory.EnumerateDirectories(Path.Combine($"{driveletter}:\\", "nimbusmodules")))
                {
                    if (folder.Contains("BC02"))
                        juxtregion = 'C'; // JPN
                    else if (folder.Contains("BD02"))
                        juxtregion = 'D'; // USA
                    else if (folder.Contains("BE02"))
                        juxtregion = 'E'; // EUR
                }

                Modules["juxt"] = Modules["juxt"].Replace('x', juxtregion); // set juxt region correctly
                CTRToolManager ctrToolManager = new();
                ctrToolManager.FilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "ctrtool.exe");
                if (!File.Exists(ctrToolManager.FilePath))
                    ctrToolManager.Download();

                foreach (KeyValuePair<string, string> module in Modules)
                {
                    Console.WriteLine($"Extracting and decompressing code.bin for {module.Value} ({module.Key} module)...");
                    ctrToolManager.ExtractCode(Path.Combine($"{driveletter}:\\", "nimbusmodules", module.Value), Path.Combine(args[0], "patches", module.Key));
                    Console.WriteLine("Decompressed!");
                }

                Console.WriteLine("\n\nEverything has been extracted. Press any key to exit...");
                Console.ReadKey(true);
                Environment.Exit(0);

            }
            else
            {
                Console.WriteLine("Errors have been found:");
                foreach (string error in Errors)
                {
                    Console.WriteLine($"  {error}");
                }
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey(true);
                Environment.Exit(-1);
            }
        }
    }
}