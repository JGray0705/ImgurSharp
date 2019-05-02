using ImgurSharp.API.Endpoints;
using ImgurSharp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImgurSharp.API {
    public class ImgurClient : IDisposable{
        private static ImgurHttp imgurHttp;
        public string ClientId { get; }

        public ImgurClient(string clientId) {
            ClientId = clientId;
            imgurHttp = new ImgurHttp(ClientId);
        }
        public ImgurClient(string clientId, string accessToken) {
            ClientId = clientId;
            imgurHttp = new ImgurHttp(ClientId, accessToken);
        }

        public async Task<Gallery> GetGallery(string galleryId) {
            Gallery gallery = await GalleryEndpoint.GetGallery(galleryId, imgurHttp);
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

        public async Task<List<Comment>> GetCommentWithReplies(int commentId) {
            List<Comment> comments = await CommentEndpoint.GetCommentWithReplies(commentId, imgurHttp);
            return comments;
        }

        public async Task<Account> GetAccount(string username) {
            Account account = await AccountEndpoint.GetAccount(username, imgurHttp);
            return account;
        }

        public async Task<List<Comment>> GetAccountComments(string username, int limit) {
            return await CommentEndpoint.GetAccountComments(username, limit, imgurHttp);
        }

        public async Task<bool> PostCommentReply(int parentID, string text) {
            bool success = await CommentEndpoint.PostCommentReply(parentID, text, imgurHttp);
            return success;
        }

        public void Dispose() {
            ((IDisposable)imgurHttp).Dispose();
        }
    }
}
