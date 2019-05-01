using ImgurSharp.Enums;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace ImgurSharp.Models{
    public class Comment {
        /// <summary>
        /// The ID for the comment
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; }
        /// <summary>
        /// The ID of the image that the comment is for
        /// </summary>
        [JsonProperty("image_id")]
        public string ImageId { get; }
        /// <summary>
        /// The content of the comment
        /// </summary>
        [JsonProperty("comment")]
        public string Content { get; }
        ///<summary>
        ///The username of the author of the comment
        /// </summary>
        [JsonProperty("author")]
        public string Author { get; }
        ///<summary>
        ///The account ID for the author
        /// </summary>
        [JsonProperty("author_id")]
        public int AuthorID { get; }
        ///<summary>
        ///If this comment was done to an album
        ///</summary>
        [JsonProperty("on_album")]
        public bool OnAlbum { get; }
        ///<summary>
        ///The ID of the album cover image, this is what should be displayed for album comments
        ///</summary>
        [JsonProperty("album_cover")]
        public string AlbumCover { get; }
        ///<summary>
        ///Number of upvotes for the comment
        ///</summary>
        [JsonProperty("ups")]
        public int Ups { get; }
        ///<summary>
        ///Number of downvotes for the comment
        ///</summary>
        [JsonProperty("downs")]
        public int Downs { get; }
        ///<summary>
        ///the number of upvotes - downvotes
        ///</summary>
        [JsonProperty("points")]
        public int Points { get; }
        ///<summary>
        ///Timestamp of creation, epoch time
        ///</summary>
        [JsonProperty("datetime")]
        public int Timestamp { get; }
        ///<summary>
        ///If this is a reply, this will be the value of the comment_id for the caption this a reply for.
        ///This will be 0 if it is not a reply.
        ///</summary>
        [JsonProperty("parent_id")]
        public int ParentID { get; }
        ///<summary>
        ///Marked true if this caption has been deleted
        ///</summary>
        [JsonProperty("deleted")]
        public bool IsDeleted { get; }
        ///<summary>
        ///The current user's vote on the comment. null if not signed in or if the user hasn't voted on it.
        ///</summary>
        [JsonProperty("vote")]
        public Vote? Vote { get; }
        ///<summary>
        ///All of the replies for this comment. If there are no replies to the comment then this is an empty set.
        ///</summary>
        [JsonIgnore]
        public Comment[] Children;

        public Comment(int id, string imageId, string content, string author, int authorID, bool onAlbum, string albumCover, int ups, int downs, int points, int timestamp, int parentID, bool isDeleted, Vote? vote, Comment[] children) {
            Id = id;
            ImageId = imageId;
            Content = content;
            Author = author;
            AuthorID = authorID;
            OnAlbum = onAlbum;
            AlbumCover = albumCover;
            Ups = ups;
            Downs = downs;
            Points = points;
            Timestamp = timestamp;
            ParentID = parentID;
            IsDeleted = isDeleted;
            Vote = vote;
            Children = children;
        }

        public override string ToString() {
            string result = "";
            foreach (var prop in GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
                string value = prop.GetValue(this) == null ? "null" : prop.GetValue(this).ToString();

                result += $"{prop.Name}: {value}\n";
            }
            return result;
        }
    }
}
