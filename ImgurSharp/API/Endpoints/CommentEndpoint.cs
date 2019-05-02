using ImgurSharp.Models;
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

        public static async Task<List<Comment>> GetAccountComments(string accountUsername, int limit, ImgurHttp imgurHttp) {
            string url = $"account/{accountUsername}/comments/ids";
            List<int> commentIds = await imgurHttp.MakeRequest<List<int>>(url);
            List<Comment> comments = new List<Comment>();
            for(int i = 0; i < limit; i++) {
                comments.Add(await GetComment(commentIds[i], imgurHttp));
            }
            return comments;
        }

        public static async Task<bool> PostCommentReply(int parentCommentId, string text, ImgurHttp imgurHttp) {
            string url = $"comment";
            return await imgurHttp.PostComment(url, text, parentCommentId);
        }
    }
}
