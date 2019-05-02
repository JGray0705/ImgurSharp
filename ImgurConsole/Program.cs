using System;
using System.Threading.Tasks;
using ImgurSharp.API;

namespace ImgurConsole {
    class Program {
        static async Task Main(string[] args) {
            using(ImgurClient client = new ImgurClient("", "")) {

                var gallery = client.GetGallery("Rhz76nz");
                Console.WriteLine(gallery.ToString());

                var img = await client.GetImage("4imzFm2");
                Console.WriteLine(img.ToString());

                var comment = await client.GetComment(1639400349);
                Console.WriteLine(comment.ToString());
                
                var replies = await client.GetCommentWithReplies(1639400349);
                foreach (var reply in replies) {
                    Console.WriteLine(reply.ToString());
                }

                var account = await client.GetAccount("cleverheather");
                Console.WriteLine(account.ToString());

                var comments = await client.GetAccountComments("cleverheather", 5);
                foreach(var c in comments) {
                    Console.WriteLine(c.ToString());
                }

                //var commentMade = await client.PostCommentReply(1588937269, "Hello, it's me.");
                //Console.WriteLine(commentMade);
                Console.ReadLine();
            }
        }
    }
}
