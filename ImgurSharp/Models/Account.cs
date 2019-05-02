using Newtonsoft.Json;
using System.Reflection;

namespace ImgurSharp.Models {
    public class Account {
        [JsonProperty("id")]
        public int Id { get; }
        [JsonProperty("url")]
        public string Url { get; }
        [JsonProperty("bio")]
        public string Bio { get; }
        [JsonProperty("reputation")]
        public int Reputation { get; }
        [JsonProperty("reputation_name")]
        public string ReputationName { get; }
        [JsonProperty("created")]
        public int Created { get; }

        public Account(int id, string url, string bio, int reputation, string reputationName, int created) {
            Id = id;
            Url = url;
            Bio = bio;
            Reputation = reputation;
            ReputationName = reputationName;
            Created = created;
        }

        public override string ToString() {
            string result = "";
            foreach (var prop in GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
                string value = prop.GetValue(this) == null ? "" : prop.GetValue(this).ToString();

                result += $"{prop.Name}: {value}\n";
            }
            return result;
        }
    }
}
