using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ImgurSharp.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ImgurSharp.API{
    public class ImgurClient : HttpClient{

        string ClientId;
        string ClientSecret;
        string AccessToken;
        const string BaseURL = "https://api.imgur.com/3/";

        public ImgurClient(string clientId, string clientSecret = null, string accessToken = null) {
            ClientId = clientId;
            ClientSecret = clientSecret;
            AccessToken = accessToken;
            DefaultRequestHeaders.Add("Authorization", $"Client-Id {ClientId}");
        }

        public async Task<Image> GetImage(string imageId) {
            string url = $"{BaseURL}image/{imageId}";
            Image img = await MakeRequest<Image>(url);

            return img;
        }

        public async Task<T> MakeRequest<T>(string url) {
            HttpResponseMessage response = await GetAsync(url);
            response.EnsureSuccessStatusCode();

            JObject result = JObject.Parse(await response.Content.ReadAsStringAsync());
            return result.ToObject<T>();            
        }
    }
}
