using ImgurSharp.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurSharp.Models {
    public class GalleryObject {
        [JsonProperty("id")]
        public string Id { get; }
        [JsonProperty("title")]
        public string Title { get; }
        [JsonProperty("description")]
        public string Description { get; }
        [JsonProperty("datetime")]
        public int DateTime { get; }
        [JsonProperty("views")]
        public int Views { get; }
        [JsonProperty("vote")]
        public Vote? Vote { get; }
        [JsonProperty("favorite")]
        public bool? Favorite { get; }
        [JsonProperty("nsfw")]
        public bool? Nsfw { get; }
        [JsonProperty("account_url")]
        public string AccountUrl { get; }
        [JsonProperty("account_id")]
        public int? AccountId { get; }
        [JsonProperty("link")]
        public string Link { get; }
        [JsonProperty("ups")]
        public int Ups { get; }
        [JsonProperty("downs")]
        public int Downs { get; }
        [JsonProperty("points")]
        public int Points { get; }
        [JsonProperty("score")]
        public int Score { get; }
        [JsonProperty("is_album")]
        public bool IsAlbum { get; }
        [JsonProperty("comment_count")]
        public int CommentCount { get; }
        [JsonProperty("favorite_count")]
        public int FavoriteCount { get; }
        [JsonProperty("topic")]
        public string Topic { get; }
        [JsonProperty("topic_id")]
        public int TopicId { get; }
        [JsonProperty("tags")]
        public Tag[] Tags { get; }
    }
}
