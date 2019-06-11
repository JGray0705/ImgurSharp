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

        public async Task<Album> CreateAlbumAsync() {
            Album album = await GalleryEndpoint.CreateAlbumAsync(imgurHttp);
            return album;
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

        public async Task<List<Comment>> GetAccountComments(string username, int limit, string sort = "newest") {
            return await CommentEndpoint.GetAccountComments(username, limit, sort, imgurHttp);
        }

        public async Task<bool> PostCommentReply(int parentID, string imageId, string text) {
            bool success = await CommentEndpoint.PostCommentReply(parentID, imageId, text, imgurHttp);
            return success;
        }

        public async Task<Image> PostImageAnonymouslyAsync(string imageUrl, string albumHash) {
            return await ImageEndpoint.PostImageAnonymouslyAsync(imageUrl, albumHash, imgurHttp);
        }
        public async Task<bool> CheckRateLimit() {
            return await imgurHttp.CheckRateLimit();
        }

        public async Task<int> GetAccountCommentCount(string username) {
            return await CommentEndpoint.GetAccountCommentCount(username, imgurHttp);
        }

        public async Task<List<string>> GetAccountAlbumIds(string username, int page = 0) {
            return await GalleryEndpoint.GetAccountAlbumIds(username, page, imgurHttp);
        } 

        public async Task<int> GetTotalAlbumsAsync(string username) {
            return await AccountEndpoint.GetTotaAlbumsAsync(username, imgurHttp);
        }

        public async Task<int> GetTotalImagesAsync(string username) {
            return await AccountEndpoint.GetTotalImagesAsync(username, imgurHttp);
        }

        public void Dispose() {
            ((IDisposable)imgurHttp).Dispose();
        }
    }
}
