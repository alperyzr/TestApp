using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Core.Application.Users.ViewModels
{
    public class UserDto : _BaseDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Zorunludur.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Kullanıcı Soyadı Zorunludur.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Zorunludur.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Zorunludur.")]
        public string Password { get; set; } 
      
        public DateTime? BirthDate { get; set; } 

        public string ImagePath { get; set; }

        public string? ResreshToken { get; set; }

        public DateTime? RefreshTokenEndDate { get; set; }


    }
}
