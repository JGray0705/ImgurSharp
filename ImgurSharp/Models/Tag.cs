using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurSharp.Models {
    public class Tag {
        public string Name { get; }
        public int Followers { get; }
        [JsonProperty("total_followers")]
        public int TotalItems { get; }
        public bool? Following { get; }

        public Tag(string name, int followers, int totalItems, bool? following) {
            Name = name;
            Followers = followers;
            TotalItems = totalItems;
            Following = following;
        }
    }
}
