using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurSharp.Models {
    public class Trophy {
        /// <summary>
        /// The ID of the trophy, this is unique to each trophy
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// The name of the trophy
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Can be thought of as the ID of a trophy type
        /// </summary>
        [JsonProperty("name_clean")]
        public string CleanName { get; set; }
        /// <summary>
        /// A description of the trophy and how it was earned.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// The ID of the image or the ID of the comment where the trophy was earned
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }
        /// <summary>
        /// A link to where the trophy was earned
        /// </summary>
        [JsonProperty("data_link")]
        public string DataLink { get; set; }
        /// <summary>
        /// Date the trophy was earned, epoch time
        /// </summary>
        [JsonProperty("datetime")]
        public int Timestamp { get; set; }
        /// <summary>
        /// URL of the image representing the trophy
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; set; }
    }
}
