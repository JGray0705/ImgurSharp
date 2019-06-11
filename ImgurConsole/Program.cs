using System;
using System.Threading.Tasks;
using ImgurSharp.API;
using LiteDB;

namespace ImgurConsole {
    class Program {
        static async Task Main(string[] args) {
            using (ImgurClient client = new ImgurClient(ApiKeys.ImgurClientIdNoAuth, ApiKeys.ImgurAccessTokenCommentBot)) {
                //var image1 = await client.GetImage("Yb3Xv1r");
                //Console.WriteLine(image1.Id);
                var album = await client.CreateAlbumAsync();
                string albumHash = album.DeleteHash;
                using (var db = new LiteDatabase("C:\\Users\\Git\\DiscordBot\\JeffBot\\JeffBot\\bin\\Debug\\netcoreapp2.1\\hugs.db")) {
                    var table = db.GetCollection<HugData>("hugs");
                    var hugs = table.FindAll();
                    Console.WriteLine(album.Id);
                    foreach (var hug in hugs) {
                        Console.WriteLine(hug.Text);
                        try {
                            var image = await client.PostImageAnonymouslyAsync(hug.Text, albumHash);
                            hug.Text = $"https://imgur.com/{image.Id}";
                            table.Update(hug);
                            Console.WriteLine(hug.Text);
                        }
                        catch {
                            Console.WriteLine("NOPE");
                        }
                        await Task.Delay(5000);
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
