using ImgurSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurSharp.API.Endpoints {
    class GalleryEndpoint {
        public static async Task<Gallery> GetGallery(string galleryId, ImgurHttp imgurHttp) {
            string url = $"gallery/{galleryId}";
            return await imgurHttp.MakeRequest<Gallery>(url);
        }
    }
}
