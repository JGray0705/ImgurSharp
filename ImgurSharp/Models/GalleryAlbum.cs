using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurSharp.Models {
    public class GalleryAlbum : GalleryObject {
        [JsonProperty("cover")]
        public string Cover { get; }
        [JsonProperty("cover_width")]
        public int CoverWidth { get; }
        [JsonProperty("cover_height")]
        public int CoverHeight { get; }
        [JsonProperty("privacy")]
        public string Privay { get; }
        [JsonProperty("layout")]
        public string Layout { get; }
        [JsonProperty("images_count")]
        public int ImageCount { get; }
        [JsonProperty("images")]
        public Image[] Images { get; }
    }
}
