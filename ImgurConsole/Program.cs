using System;
using System.Threading.Tasks;
using ImgurSharp.API;

namespace ImgurConsole {
    class Program {
        static async Task Main(string[] args) {
            using(ImgurClient client = new ImgurClient("9a03df3d974f8c9")) {

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
                Console.ReadLine();
            }
        }
    }
}
