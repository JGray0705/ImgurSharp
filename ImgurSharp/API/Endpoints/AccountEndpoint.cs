using ImgurSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurSharp.API.Endpoints {
    class AccountEndpoint {
        public static async Task<Account> GetAccount(string username, ImgurHttp imgurHttp) {
            string url = $"account/{username}";
            return await imgurHttp.MakeRequest<Account>(url);
        }
    }
}
