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

        public static async Task<Album> CreateAlbumAsync(ImgurHttp imgurHttp) {
            string url = "album";
            return await imgurHttp.CreateAlbumAsync(url);
        }

        public static async Task<List<string>> GetAccountAlbumIds(string username, int page, ImgurHttp imgurHttp) {
            string url = $"account/{username}/albums/ids/{page}/newest";
            return await imgurHttp.MakeRequest<List<string>>(url);
        }
    }
}
