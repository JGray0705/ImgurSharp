using Newtonsoft.Json;

namespace ImgurSharp.Models {
    /// <summary>
    /// This is the basic response for requests that do not return data. If the POST request has a Basic model it will return the id.
    /// </summary>
    public class Basic {
        /// <summary>
        /// Is null, boolean, or integer value. If it's a post then this will contain an object with the all generated values, such as an ID.
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; }
        /// <summary>
        /// Was the request successful
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; }
        /// <summary>
        /// HTTP Status Code
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; }
    }
}
