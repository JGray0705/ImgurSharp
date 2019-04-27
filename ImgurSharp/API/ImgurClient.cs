using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ImgurSharp.Entities;
using Newtonsoft.Json.Linq;

namespace ImgurSharp.API {
    /// <summary>
    /// Class ImgurClient is used to access the Imgur API endpoints.
    /// ClientId, ClientSecret, and AccessToken are used in the request headers for authentication.
    /// </summary>
    public class ImgurClient : HttpClient {

        /// <summary>
        /// ClientID is the ID of the Imgur app and is used in the Http header
        /// </summary>        
        string ClientId { get; }
        /// <summary>
        /// ClientSecret and AccessToken give access to a user account and are used in the Http header
        /// </summary>
        string ClientSecret { get; }
        string AccessToken { get; }

        public ImgurClient(string clientId) {
            ClientId = clientId;
            // Add the ClientId to the header. This will be used for every request
            DefaultRequestHeaders.Add("Authorization", $"Client-Id {ClientId}");
            // BaseAddress is used with every request and each method will add the proper endpoints
            BaseAddress = new Uri("https://api.imgur.com/3/");
        }

        /// <summary>
        /// Get an Image with the given ID
        /// </summary>
        /// <param name="imageId">The ID of the requested image. This is the part at the end of the URL.</param>
        /// <returns>An Imgur <see cref="Image"/></returns>
        public async Task<Image> GetImage(string imageId) {
            string url = $"image/{imageId}";
            // Request an image 
            Image img = await MakeRequest<Image>(url);

            return img;
        }

        /// <summary>
        /// Call the Imgur API using the URL param.
        /// Convert the Json response into an instance of the given type.
        /// </summary>
        /// <typeparam name="T">The type to convert the Json results to.</typeparam>
        /// <param name="url">The URL and any parameters needed for the API.</param>
        /// <returns>object created from the Json response.</returns>
        public async Task<T> MakeRequest<T>(string url) {
            // response will be a Json response from the Imgur API
            HttpResponseMessage response = await GetAsync(url);
            response.EnsureSuccessStatusCode();

            // Get the result string and convert to Json
            JObject result = JObject.Parse(await response.Content.ReadAsStringAsync());
            // The data section of the Json contains the object attributes. Use this to create an object and return
            var obj = result["data"].ToObject<T>();
            return obj;
        }
    }
}
