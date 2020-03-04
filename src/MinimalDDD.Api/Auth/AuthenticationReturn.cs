using MinimalDDD.Domain.Aggregations.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TGAuth.Service.Auth
{
    public class AuthenticationReturn
    {
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
        public User UserAuthorized { get; set; }
        public string Message { get; set; }
    }
}
