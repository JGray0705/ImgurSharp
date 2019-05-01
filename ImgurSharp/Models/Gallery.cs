using Newtonsoft.Json;

namespace ImgurSharp.Models {
    public class Gallery : Album {
        [JsonProperty("ups")]
        public int Ups { get; }
        [JsonProperty("downs")]
        public int Downs { get; }
        [JsonProperty("points")]
        public int Points { get; }
        [JsonProperty("score")]
        public int Score { get; }
        [JsonProperty("is_album")]
        public bool IsAlbum { get; }
        [JsonProperty("comment_count")]
        public int CommentCount { get; }
        [JsonProperty("favorite_count")]
        public int FavoriteCount { get; }

        public Gallery(int ups, int downs, int points, int score, bool isAlbum, int commentCount, int favoriteCount, string id, string title, string description, int datetime, string cover, int coverWidth, int coverHeight, string accountUrl, string accountId, string privacy, string layout, int views, string link, bool favorite, bool nsfw, string section, int order, string deleteHash, int imagesCount, Image[] images, bool inGallery) : 
            base(id, title, description, datetime, cover, coverWidth, coverHeight, accountUrl, accountId, privacy, layout, views, link, favorite, nsfw, section, order, deleteHash, imagesCount, images, inGallery) {
            Ups = ups;
            Downs = downs;
            Points = points;
            Score = score;
            IsAlbum = isAlbum;
            CommentCount = commentCount;
            FavoriteCount = favoriteCount;
        }
    }
}
