using Newtonsoft.Json;
using System.Reflection;

namespace ImgurSharp.Models {
    public class Album {
        /// <summary>
        /// The ID for the album
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }
        /// <summary>
        /// The title of the album in the gallery
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; }
        /// <summary>
        /// The description of the album in the gallery
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }
        /// <summary>
        /// Time inserted into the gallery, epoch time
        /// </summary>
        [JsonProperty("datetime")]
        public int Datetime { get; }
        /// <summary>
        /// Id of the thumbnail image
        /// </summary>
        [JsonProperty("cover")]
        public string Cover { get; }
        /// <summary>
        /// Width of the thumbnail image
        /// </summary>
        [JsonProperty("cover_width")]
        public int CoverWidth { get; }
        /// <summary>
        /// Height of the thumbnail image
        /// </summary>
        [JsonProperty("cover_height")]
        public int CoverHeight { get; }
        /// <summary>
        /// Url of the album owner. Null if anonymous album.
        /// </summary>
        [JsonProperty("account_url")]
        public string AccountUrl { get; }
        /// <summary>
        /// ID of the album owner. Null if anonymous.
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; }
        /// <summary>
        /// The privacy level of the album, you can only view public if not logged in as album owner
        /// </summary>
        [JsonProperty("privacy")]
        public string Privacy { get; } // ????
        /// <summary>
        /// The view layout of the album.
        /// </summary>
        [JsonProperty("layout")]
        public string Layout { get; } // Also ???
        /// <summary>
        /// The number of album views
        /// </summary>
        [JsonProperty("views")]
        public int Views { get; }
        /// <summary>
        /// The URL link to the album
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; }
        /// <summary>
        /// Indicates if the current user favorited the image. Defaults to false if not signed in.
        /// </summary>
        [JsonProperty("favorite")]
        public bool? Favorite { get; }
        /// <summary>
        /// Indicates if the image has been marked as nsfw or not. Defaults to null if information is not available.
        /// </summary>
        [JsonProperty("nsfw")]
        public bool? Nsfw { get; }
        /// <summary>
        /// If the image has been categorized by our backend then this will contain the section the image belongs in. (funny, cats, adviceanimals, wtf, etc)
        /// </summary>
        [JsonProperty("section")]
        public string Section { get; }
        /// <summary>
        /// Order number of the album on the user's album page (defaults to 0 if their albums haven't been reordered)
        /// </summary>
        [JsonProperty("order")]
        public int Order { get; }
        /// <summary>
        /// OPTIONAL, the deletehash, if you're logged in as the album owner
        /// </summary>
        [JsonProperty("deletehash")]
        public string DeleteHash { get; }
        /// <summary>
        /// The total number of images in the album
        /// </summary>
        [JsonProperty("images_count")]
        public int ImagesCount { get; }
        /// <summary>
        /// An array of all the images in the album (only available when requesting the direct album)
        /// </summary>
        [JsonProperty("images")]
        public Image[] Images { get; }
        /// <summary>
        /// True if the image has been submitted to the gallery, false if otherwise.
        /// </summary>
        [JsonProperty("in_gallery")]
        public bool? InGallery { get; }

        public Album(string id, string title, string description, int datetime, string cover, int coverWidth, int coverHeight, string accountUrl, string accountId, string privacy, string layout, int views, string link, bool? favorite, bool? nsfw, string section, int order, string deleteHash, int imagesCount, Image[] images, bool? inGallery) {
            Id = id;
            Title = title;
            Description = description;
            Datetime = datetime;
            Cover = cover;
            CoverWidth = coverWidth;
            CoverHeight = coverHeight;
            AccountUrl = accountUrl;
            AccountId = accountId;
            Privacy = privacy;
            Layout = layout;
            Views = views;
            Link = link;
            Favorite = favorite;
            Nsfw = nsfw;
            Section = section;
            Order = order;
            DeleteHash = deleteHash;
            ImagesCount = imagesCount;
            Images = images;
            InGallery = inGallery;
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
