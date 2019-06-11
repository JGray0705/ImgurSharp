using System.Threading.Tasks;
using ImgurSharp.Models;

namespace ImgurSharp.API.Endpoints {
    class ImageEndpoint {

        public static async Task<Image> GetImage(string imageId, ImgurHttp imgurHttp) {
            string url = $"image/{imageId}";
            Image img = await imgurHttp.MakeRequest<Image>(url);
            return img;
        }

        public static async Task<Image> PostImageAnonymouslyAsync(string imageUrl, string albumHash, ImgurHttp imgurHttp) {
            string url = "upload";
            Image img = await imgurHttp.PostImageAnonymouslyAsync(url, imageUrl, albumHash);
            return img;
        }
    }
}
