using ImgurSharp.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurSharp.API.Endpoints {
    class AccountEndpoint {
        public static async Task<Account> GetAccount(string username, ImgurHttp imgurHttp) {
            string url = $"account/{username}";
            return await imgurHttp.MakeRequest<Account>(url);
        }

        public static async Task<int> GetTotalImagesAsync(string username, ImgurHttp imgurHttp) {
            // requires auth
            string url = $"account/{username}/images/count";

            var request = await imgurHttp.GetAsync(url);

            // parsing it here because too lazy to make a whole object for this one thing
            var response = await request.Content.ReadAsStringAsync();
            JObject result = JObject.Parse(response);
            if (result.TryGetValue("data", out JToken count)) {
                return (int)count;
            }
            return -1;
        }

        public static async Task<GalleryObject[]> GetAccountSubmissions(string username, ImgurHttp imgurHttp) {
            string url = $"account/{username}/submissions";
            return await imgurHttp.MakeRequest<GalleryObject[]>(url);
        }
    }
}
