using ImgurSharp.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace ImgurSharp.Models {

    public class Image {
        [JsonProperty("id")]
        public string Id { get; }
        [JsonProperty("title")]
        public string Title { get; }
        [JsonProperty("description")]
        public string Description { get; }
        [JsonProperty("datetime")]
        public int DateTime { get; }
        [JsonProperty("type")]
        public string Type { get; }
        [JsonProperty("animated")]
        public bool? Animated { get; }
        [JsonProperty("height")]
        public int Height { get; }
        [JsonProperty("width")]
        public int Width { get; }
        [JsonProperty("size")]
        public int Size { get; }
        [JsonProperty("views")]
        public int Views { get; }
        [JsonProperty("bandwidth")]
        public string Bandwidth { get; }
        [JsonProperty("vote")]
        public Vote? Vote { get; }
        [JsonProperty("favorite")]
        public bool? Favorite { get; }
        [JsonProperty("nsfw")]
        public bool? Nsfw { get; }
        [JsonProperty("section")]
        public string Section { get; }
        [JsonProperty("account_url")]
        public string AccountUrl { get; }
        [JsonProperty("account_id")]
        public int? AccountId { get; }
        [JsonProperty("in_most_viral")]
        public bool? MostViral { get; }
        [JsonProperty("tags")]
        public Tag[] Tags { get; }
        [JsonProperty("is_ad")]
        public bool IsAd { get; }
        [JsonProperty("in_gallery")]
        public bool? InGallery { get; }
        [JsonProperty("deletehash")]
        public string DeleteHash { get; }
        [JsonProperty("name")]
        public string Name { get; }
        [JsonProperty("link")]
        public string Link { get; }

        public Image(string id, string title, string description, int dateTime, string type, bool animated, int height, int width, int size, int views, string bandwidth, Vote? vote, bool? favorite, bool? nsfw, string section, string accountUrl, int? accountId, bool? mostViral, Tag[] tags, bool isAd, bool? inGallery, string deleteHash, string name, string link) {
            Id = id;
            Title = title;
            Description = description;
            DateTime = dateTime;
            Type = type;
            Animated = animated;
            Height = height;
            Width = width;
            Size = size;
            Views = views;
            Bandwidth = bandwidth;
            Vote = vote;
            Favorite = favorite;
            Nsfw = nsfw;
            Section = section;
            AccountUrl = accountUrl;
            AccountId = accountId;
            MostViral = mostViral;
            Tags = tags;
            IsAd = isAd;
            InGallery = inGallery;
            DeleteHash = deleteHash;
            Name = name;
            Link = link;
        }

        public override string ToString() {
            string result = "";
            foreach(var prop in GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
                string value = prop.GetValue(this) == null ? "" : prop.GetValue(this).ToString();

                result += $"{prop.Name}: {value}\n";
            }
            return result;
        }

        public override bool Equals(object obj) {
            return obj is Image image &&
                   Id == image.Id;
        }

        public override int GetHashCode() {
            return 2108858624 + EqualityComparer<string>.Default.GetHashCode(Id);
        }

        public static bool operator ==(Image left, Image right) {
            return EqualityComparer<Image>.Default.Equals(left, right);
        }

        public static bool operator !=(Image left, Image right) {
            return !(left == right);
        }
    }
}

