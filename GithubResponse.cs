using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ThreeDSModuleExtractor
{
    public class Asset
    {
        [JsonPropertyName("url")]
        public string url { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("node_id")]
        public string node_id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("label")]
        public object label { get; set; }

        [JsonPropertyName("uploader")]
        public Uploader uploader { get; set; }

        [JsonPropertyName("content_type")]
        public string content_type { get; set; }

        [JsonPropertyName("state")]
        public string state { get; set; }

        [JsonPropertyName("size")]
        public int size { get; set; }

        [JsonPropertyName("download_count")]
        public int download_count { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime created_at { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime updated_at { get; set; }

        [JsonPropertyName("browser_download_url")]
        public string browser_download_url { get; set; }
    }

    public class Author
    {
        [JsonPropertyName("login")]
        public string login { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("node_id")]
        public string node_id { get; set; }

        [JsonPropertyName("avatar_url")]
        public string avatar_url { get; set; }

        [JsonPropertyName("gravatar_id")]
        public string gravatar_id { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }

        [JsonPropertyName("html_url")]
        public string html_url { get; set; }

        [JsonPropertyName("followers_url")]
        public string followers_url { get; set; }

        [JsonPropertyName("following_url")]
        public string following_url { get; set; }

        [JsonPropertyName("gists_url")]
        public string gists_url { get; set; }

        [JsonPropertyName("starred_url")]
        public string starred_url { get; set; }

        [JsonPropertyName("subscriptions_url")]
        public string subscriptions_url { get; set; }

        [JsonPropertyName("organizations_url")]
        public string organizations_url { get; set; }

        [JsonPropertyName("repos_url")]
        public string repos_url { get; set; }

        [JsonPropertyName("events_url")]
        public string events_url { get; set; }

        [JsonPropertyName("received_events_url")]
        public string received_events_url { get; set; }

        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("site_admin")]
        public bool site_admin { get; set; }
    }

    public class Reactions
    {
        [JsonPropertyName("url")]
        public string url { get; set; }

        [JsonPropertyName("total_count")]
        public int total_count { get; set; }

        [JsonPropertyName("+1")]
        public int plus1 { get; set; }

        [JsonPropertyName("-1")]
        public int minus1 { get; set; }

        [JsonPropertyName("laugh")]
        public int laugh { get; set; }

        [JsonPropertyName("hooray")]
        public int hooray { get; set; }

        [JsonPropertyName("confused")]
        public int confused { get; set; }

        [JsonPropertyName("heart")]
        public int heart { get; set; }

        [JsonPropertyName("rocket")]
        public int rocket { get; set; }

        [JsonPropertyName("eyes")]
        public int eyes { get; set; }
    }

    public class GithubResponse
    {
        [JsonPropertyName("url")]
        public string url { get; set; }

        [JsonPropertyName("assets_url")]
        public string assets_url { get; set; }

        [JsonPropertyName("upload_url")]
        public string upload_url { get; set; }

        [JsonPropertyName("html_url")]
        public string html_url { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("author")]
        public Author author { get; set; }

        [JsonPropertyName("node_id")]
        public string node_id { get; set; }

        [JsonPropertyName("tag_name")]
        public string tag_name { get; set; }

        [JsonPropertyName("target_commitish")]
        public string target_commitish { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("draft")]
        public bool draft { get; set; }

        [JsonPropertyName("prerelease")]
        public bool prerelease { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime created_at { get; set; }

        [JsonPropertyName("published_at")]
        public DateTime published_at { get; set; }

        [JsonPropertyName("assets")]
        public List<Asset> assets { get; set; }

        [JsonPropertyName("tarball_url")]
        public string tarball_url { get; set; }

        [JsonPropertyName("zipball_url")]
        public string zipball_url { get; set; }

        [JsonPropertyName("body")]
        public string body { get; set; }

        [JsonPropertyName("reactions")]
        public Reactions reactions { get; set; }

        [JsonPropertyName("mentions_count")]
        public int mentions_count { get; set; }
    }

    public class Uploader
    {
        [JsonPropertyName("login")]
        public string login { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("node_id")]
        public string node_id { get; set; }

        [JsonPropertyName("avatar_url")]
        public string avatar_url { get; set; }

        [JsonPropertyName("gravatar_id")]
        public string gravatar_id { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }

        [JsonPropertyName("html_url")]
        public string html_url { get; set; }

        [JsonPropertyName("followers_url")]
        public string followers_url { get; set; }

        [JsonPropertyName("following_url")]
        public string following_url { get; set; }

        [JsonPropertyName("gists_url")]
        public string gists_url { get; set; }

        [JsonPropertyName("starred_url")]
        public string starred_url { get; set; }

        [JsonPropertyName("subscriptions_url")]
        public string subscriptions_url { get; set; }

        [JsonPropertyName("organizations_url")]
        public string organizations_url { get; set; }

        [JsonPropertyName("repos_url")]
        public string repos_url { get; set; }

        [JsonPropertyName("events_url")]
        public string events_url { get; set; }

        [JsonPropertyName("received_events_url")]
        public string received_events_url { get; set; }

        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("site_admin")]
        public bool site_admin { get; set; }
    }
}
