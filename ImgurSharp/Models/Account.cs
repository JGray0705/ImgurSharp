using Newtonsoft.Json;

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
    }
}
