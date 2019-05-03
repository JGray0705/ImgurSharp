using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ImgurSharp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ImgurSharp.API {
    /// <summary>
    /// Class ImgurHttp is used to access the Imgur API endpoints.
    /// ClientId, ClientSecret, and AccessToken are used in the request headers for authentication.
    /// </summary>
    class ImgurHttp : HttpClient {

        /// <summary>
        /// ClientID is the ID of the Imgur app and is used in the Http header
        /// </summary>        
        string ClientId { get; }
        /// <summary>
        /// ClientSecret and AccessToken give access to a user account and are used in the Http header
        /// </summary>
        string ClientSecret { get; }
        string AccessToken { get; }

        public ImgurHttp(string clientId) {
            ClientId = clientId;
            // BaseAddress is used with every request and each method will add the proper endpoints
            BaseAddress = new Uri("https://api.imgur.com/3/");
        }
        
        public ImgurHttp(string clientId, string accessToken) {
            ClientId = clientId;
            AccessToken = accessToken;

            // BaseAddress is used with every request and each method will add the proper endpoints
            BaseAddress = new Uri("https://api.imgur.com/3/");
        }

        /// <summary>
        /// Call the Imgur API using the URL param.
        /// Convert the Json response into an instance of the given type.
        /// </summary>
        /// <typeparam name="T">The type to convert the Json result to.</typeparam>
        /// <param name="url">The URL and any parameters needed for the API.</param>
        /// <returns>object created from the Json response.</returns>
        public async Task<T> MakeRequest<T>(string url) {
            // response will be a Json response from the Imgur API
            HttpResponseMessage response = await GetAsync(url);
            response.Headers.Add("Authorization", $"Client-Id {ClientId}");
            response.EnsureSuccessStatusCode();

            // Get the result string and convert to Json
            JObject result = JObject.Parse(await response.Content.ReadAsStringAsync());
            var obj = result["data"].ToObject<T>();
            return obj;
        }

        public async Task<List<Comment>> RequestReplies(string url) {
            HttpResponseMessage response = await GetAsync(url);
            response.Headers.Add("Authorization", $"Client-Id {ClientId}");
            response.EnsureSuccessStatusCode();
            List<Comment> replies = new List<Comment>();
            
            JObject result = JObject.Parse(await response.Content.ReadAsStringAsync());
            foreach(var child in result["data"]["children"]) {
                var reply = child.ToObject<Comment>();
                replies.Add(reply);
            }
            return replies;
        }

        public async Task<bool> PostComment(string url, string text, string imageId, int parentId = 0) {
            FormUrlEncodedContent data;
            if (parentId != 0) { 
                data = new FormUrlEncodedContent(new KeyValuePair<string, string>[] {
                    new KeyValuePair<string, string>("image_id", imageId),
                    new KeyValuePair<string, string>("parent_id", parentId.ToString()),
                    new KeyValuePair<string, string>("comment", text)
                });
            }
            else {
                data = new FormUrlEncodedContent(new KeyValuePair<string, string>[] {
                    new KeyValuePair<string, string>("image_id", "IM3NHJZ"),
                    new KeyValuePair<string, string>("comment", text)
                });
            }
            var response = await PostAsync(url, data);
            response.Headers.Add("Authorization", $"Bearer {AccessToken}");
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CheckRateLimit() {
            var response = await GetAsync("credits");
            response.Headers.Add("Authorization", $"Client-Id {ClientId}");
            var result = JObject.Parse(await response.Content.ReadAsStringAsync());
            var limits = result.ToObject<RateLimit>();
            return limits.ClientRemaining > 120 && limits.ClientRemaining > 0; 
        }
    }
}
