using System.Diagnostics;
using System.IO.Compression;
using System.Reflection;
using System.Text.Json;

namespace ThreeDSModuleExtractor
{
    public class CTRToolManager
    {
        public string FilePath;

        public void Download()
        {
            string owner = "3DSGuy";
            string repo = "Project_CTR";

            var httpClient = new HttpClient();
            var apiUrl = $"https://api.github.com/repos/{owner}/{repo}/releases";

            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)");

            using (var response = httpClient.GetAsync(apiUrl).Result)
            {
                response.EnsureSuccessStatusCode();
                var releaseJson = response.Content.ReadAsStringAsync().Result;
                var assetUrl = GetAssetUrlFromReleasesJson(releaseJson);

                using (var assetResponse = httpClient.GetAsync(assetUrl).Result)
                {
                    assetResponse.EnsureSuccessStatusCode();
                    ZipArchive zipArchive = new(assetResponse.Content.ReadAsStreamAsync().Result);
                    zipArchive.GetEntry("ctrtool.exe")!.ExtractToFile(FilePath);
                }
            }
        }

        public void ExtractCode(string inFolder, string outFolder, bool decompress = true)
        {
            string decompressOption = decompress ? "--decompresscode" : "";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "ctrtool.exe",
                Arguments = $"{decompressOption} --exefsdir=exefs \"{Path.Combine(inFolder, "exefs.bin")}\"",
                RedirectStandardOutput = true,
                WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Console.WriteLine(psi.Arguments);

            using (Process process = new Process())
            {
                process.StartInfo = psi;
                process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);

                process.Start();
                process.BeginOutputReadLine();
                process.WaitForExit();
            }

            // Move the converted code.bin to the desired path
            string convertedCodeFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "exefs", "code.bin");
            File.Move(convertedCodeFilePath, Path.Combine(outFolder, "code.bin"), true);
            Directory.Delete(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "exefs")!, true);
        }

        static string GetAssetUrlFromReleasesJson(string releaseJson)
        {
            var json = JsonSerializer.Deserialize<List<GithubResponse>>(releaseJson);
            var assetUrl = json!.Find(obj => obj.name.Contains("ctrtool", StringComparison.CurrentCultureIgnoreCase))!.assets.Find(obj => obj.name.Contains("win_x64"))!.browser_download_url;

            return assetUrl;
        }
    }
}
