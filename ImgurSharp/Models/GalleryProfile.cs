using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurSharp.Models {
    public class GalleryProfile {
        /// <summary>
        /// 	Total number of comments the user has made in the gallery
        /// </summary>
        [JsonProperty("total_gallery_comments")]
        public int TotalGalleryComments { get; set; }
        /// <summary>
        /// Total number of items favorited by the user in the gallery
        /// </summary>
        [JsonProperty("total_gallery_favorites")]
        public int TotalGalleryFavorites { get; set; }
        /// <summary>
        /// Total number of images submitted by the user.
        /// </summary>
        [JsonProperty("total_gallery_submissions")]
        public int TotalGellerySubmissions { get; set; }
        /// <summary>
        /// An array of trophies that the user has.
        /// </summary>
        [JsonProperty("trophies")]
        public Trophy[] Trophies { get; set; }
    }
}
