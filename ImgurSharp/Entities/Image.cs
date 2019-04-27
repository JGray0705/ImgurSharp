using ImgurSharp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImgurSharp.Entities {

    public class Image {
        public string Id { get; }
        public string Title { get; }
        public string Description { get; }
        public string DateTime { get; }
        public string Type { get; }
        public bool Animated { get; }
        public int Height { get; }
        public int Width { get; }
        public int Views { get; }
        public int Bandwidth { get; }
        public Vote? Vote { get; }
        public bool Favorite { get; }
        public bool NSFW { get; }
        public string Section { get; }
        public string AccountUrl { get; }
        public int AccountId { get; }
        public bool MostViral { get; }
        public string[] Tags { get; }
        public bool IsAd { get; }
        public bool InGallery { get; }
        public string DeleteHash { get; }
        public string Name { get; }
        public string Link { get; }

        public Image(string id, string title, string description, string dateTime, string type, bool animated, int height, int width, int views, int bandwidth, Vote? vote, bool favorite, bool nsfw, string section, string accountUrl, int accountId, bool mostViral, string[] tags, bool isAd, bool inGallery, string deleteHash, string name, string link) {
            Id = id;
            Title = title;
            Description = description;
            DateTime = dateTime;
            Type = type;
            Animated = animated;
            Height = height;
            Width = width;
            Views = views;
            Bandwidth = bandwidth;
            Vote = vote;
            Favorite = favorite;
            NSFW = nsfw;
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
                result += $"{prop.Name}: {prop.GetValue(this)}\n";
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

