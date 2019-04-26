using System;
using System.Threading.Tasks;
using ImgurSharp.API;
using ImgurSharp.Entities;

namespace ImgurConsole {
    class Program {
        static async Task Main(string[] args) {
            using(ImgurClient client = new ImgurClient("9a03df3d974f8c9")) {
                Image img = await client.GetImage("b2nHxW6h");

                Console.WriteLine(img.ToString());
                Console.ReadLine();
            }
        }
    }
}
