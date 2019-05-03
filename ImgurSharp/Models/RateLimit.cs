using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurSharp.Models {
    class RateLimit {
        public int UserLimit { get; }
        public int UserRemaining { get; }
        public ulong UserReset { get; } // unix epoch
        public int ClientLimit { get; }
        public int ClientRemaining { get; }

        public RateLimit(int userLimit, int userRemaining, ulong userReset, int clientLimit, int clientRemaining) {
            UserLimit = userLimit;
            UserRemaining = userRemaining;
            UserReset = userReset;
            ClientLimit = clientLimit;
            ClientRemaining = clientRemaining;
        }
    }
}
