using ImgurSharp.API.Endpoints;
using ImgurSharp.Models;
using System;
using System.Threading.Tasks;

namespace ImgurSharp.API {
    public class ImgurClient : IDisposable{
        private static ImgurHttp imgurHttp;
        public string ClientId { get; }

        public ImgurClient(string clientId) {
            ClientId = clientId;
            imgurHttp = new ImgurHttp(ClientId);
        }

        public async Task<Gallery> GetGallery(string galleryId) {
            string url = $"gallery/{galleryId}";
            Gallery gallery = await imgurHttp.MakeRequest<Gallery>(url);

            return gallery;
        }

        /// <summary>
        /// Get an Image with the given ID
        /// </summary>
        /// <param name="imageId">The ID of the requested image. This is the part at the end of the URL.</param>
        /// <returns>An Imgur <see cref="Image"/></returns>
        public async Task<Image> GetImage(string imageId) {
            Image img = await ImageEndpoint.GetImage(imageId, imgurHttp);
            return img;
        }

        public async Task<Comment> GetComment(int commentId) {
            Comment comment = await CommentEndpoint.GetComment(commentId, imgurHttp);
            return comment;
        }

        public async Task<Comment[]> GetCommentWithReplies(int commentId) {
            Comment[] comments = await CommentEndpoint.GetCommentWithReplies(commentId, imgurHttp);
            return comments;
        }

        public void Dispose() {
            ((IDisposable)imgurHttp).Dispose();
        }
    }
}
