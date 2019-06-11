using ImgurSharp.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImgurSharp.API.Endpoints {
    class CommentEndpoint {
        public static async Task<Comment> GetComment(int commentId, ImgurHttp imgurHttp) {
            string url = $"comment/{commentId}";
            Comment comment = await imgurHttp.MakeRequest<Comment>(url);
            return comment;
        }

        public static async Task<List<Comment>> GetCommentWithReplies(int commentId, ImgurHttp imgurHttp) {
            string url = $"comment/{commentId}/replies";
            List<Comment> comments = await imgurHttp.RequestReplies(url);
            return comments;
        }

        public static async Task<List<Comment>> GetAccountComments(string accountUsername, int limit, string sort, ImgurHttp imgurHttp) {
            string url = $"account/{accountUsername}/comments/ids/{sort}";
            List<int> commentIds = await imgurHttp.MakeRequest<List<int>>(url);
            List<Comment> comments = new List<Comment>();
            for(int i = 0; i < limit; i++) {
                comments.Add(await GetComment(commentIds[i], imgurHttp));
            }
            return comments;
        }

        public static async Task<bool> PostCommentReply(int parentCommentId, string imageId, string text, ImgurHttp imgurHttp) {
            string url = $"comment";
            return await imgurHttp.PostComment(url, text, imageId, parentCommentId);
        }

        public static async Task<int> GetAccountCommentCount(string username, ImgurHttp imgurHttp) {
            string url = $"account/{username}/comments/count";
            var request = await imgurHttp.GetAsync(url);

            // parsing it here because too lazy to make a whole object for this one thing
            var response = await request.Content.ReadAsStringAsync();
            JObject result = JObject.Parse(response);
            if(result.TryGetValue("data", out JToken count)) {
                return (int)count;
            }
            return -1;
        } 
    }
}
