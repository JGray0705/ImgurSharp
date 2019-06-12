using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurSharp.Models {
    public class Tag {
        [JsonProperty("name")]
        public string Name { get; }
        [JsonProperty("display_name")]
        public string DisplayName { get; }
        [JsonProperty("following")]
        public bool? Following { get; }
        [JsonProperty("followers")]
        public int Followers { get; }
        [JsonProperty("total_items")]
        public int TotalItems { get; }
        [JsonProperty("background_hash")]
        public string BackgroundHash { get; }
        [JsonProperty("thumbnail_hash")]
        public string ThumbnailHash { get; }
        [JsonProperty("accent")]
        public string Accent { get; }
        [JsonProperty("background_is_animated")]
        public bool? HasAnimatedBackground { get; }
        [JsonProperty("thumbnail_is_animated")]
        public bool? HasAnimatedThumbnail { get; }
        [JsonProperty("is_promoted")]
        public bool? IsPromoted { get; }
        [JsonProperty("description")]
        public string Description { get; }
        [JsonProperty("logo_hash")]
        public string LogoHash { get; }
        [JsonProperty("logo_destination_url")]
        public string LogoDestinationUrl { get; }
        [JsonProperty("description_annotations")]
        public object DescriptionAnnotation { get; }

        public Tag(string name, string displayName, bool? following, int followers, int totalItems, string backgroundHash, string thumbnailHash, string accent, bool? hasAnimatedBackground, bool? hasAnimatedThumbnail, bool? isPromoted, string description, string logoHash, string logoDestinationUrl, object descriptionAnnotation) {
            Name = name;
            DisplayName = displayName;
            Following = following;
            Followers = followers;
            TotalItems = totalItems;
            BackgroundHash = backgroundHash;
            ThumbnailHash = thumbnailHash;
            Accent = accent;
            HasAnimatedBackground = hasAnimatedBackground;
            HasAnimatedThumbnail = hasAnimatedThumbnail;
            IsPromoted = isPromoted;
            Description = description;
            LogoHash = logoHash;
            LogoDestinationUrl = logoDestinationUrl;
            DescriptionAnnotation = descriptionAnnotation;
        }
    }
}
