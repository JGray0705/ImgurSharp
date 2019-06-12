using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurSharp.Models {
    public class GalleryImage : GalleryObject {
        [JsonProperty("type")]
        public string Type { get; set; }
        public bool? Animated { get; }
        [JsonProperty("height")]
        public int Height { get; }
        [JsonProperty("width")]
        public int Width { get; }
        [JsonProperty("size")]
        public int Size { get; }
        [JsonProperty("bandwidth")]
        public string Bandwidth { get; }
        [JsonProperty("section")]
        public string Section { get; }
        [JsonProperty("deletehash")]
        public string DeleteHash { get; }
    }
}
