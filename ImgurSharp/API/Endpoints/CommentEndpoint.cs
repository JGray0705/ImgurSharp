using ImgurSharp.Models;
using System.Threading.Tasks;

namespace ImgurSharp.API.Endpoints {
    class CommentEndpoint {
        public static async Task<Comment> GetComment(int commentId, ImgurHttp imgurHttp) {
            string url = $"comment/{commentId}";
            Comment comment = await imgurHttp.MakeRequest<Comment>(url);
            return comment;
        }

        public static async Task<Comment[]> GetCommentWithReplies(int commentId, ImgurHttp imgurHttp) {
            string url = $"comment/{commentId}/replies";
            Comment[] comments = await imgurHttp.RequestReplies(url);
            return comments;
        }
    }
}
