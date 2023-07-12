using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Core.Application.Users.ViewModels
{
    public class UserDto : _BaseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; } 
        public DateTime? BirthDate { get; set; } 
        public string ImagePath { get; set; } 
        

    }
}
