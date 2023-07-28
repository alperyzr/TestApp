using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Entities;

namespace TestApp.Core.Application.Login.ViewModels
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }       
        public string UserName { get; set; }       
        public User User { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
