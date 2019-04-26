using ImgurSharp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurSharp.Entities {

    public class Image {
        string Id { get; }
        string Title { get; }
        string Description { get; }
        DateTimeOffset DateTime { get; }
        string Type { get; }
        bool Animated { get; }
        int Height { get; }
        int Width { get; }
        int Views { get; }
        int Bandwidth { get; }
        Vote Vote { get; }
        bool Favorite { get; }
        bool NSFW { get; }
        string Section { get; }
        string AccountUrl { get; }
        int AccountId { get; }
        bool MostViral { get; }
        string[] Tags { get; }
        bool IsAd { get; }
        bool InGallery { get; }
        string DeleteHash { get; }
        string Name { get; }
        string Link { get; }

        public Image(string id, string title, string description, DateTimeOffset dateTime, string type, bool animated, int height, int width, int views, int bandwidth, Vote vote, bool favorite, bool nsfw, string section, string accountUrl, int accountId, bool mostViral, string[] tags, bool isAd, bool inGallery, string deleteHash, string name, string link) {
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
            return $"{Title}. By {AccountUrl} on {DateTime}. {Views} views.";
        }
    }
}

