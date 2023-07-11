using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Core.Entities
{
    public class User:_BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<UrlShort> UrlShorts { get; set; }


    }
}
