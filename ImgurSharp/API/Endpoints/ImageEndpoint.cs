using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImgurSharp.Models;

namespace ImgurSharp.API.Endpoints {
    class ImageEndpoint {

        public static async Task<Image> GetImage(string imageId, ImgurHttp imgurHttp) {
            string url = $"image/{imageId}";
            Image img = await imgurHttp.MakeRequest<Image>(url);
            return img;
        }
    }
}
