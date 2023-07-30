using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Entities;

namespace TestApp.Core.Application.UserRoles.ViewModels
{
    public class UserRoleDto: _BaseDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }    
        public string UserName { get; set; }

        [Display(Name = "Rol Adı")]
        public string RoleName { get; set; }       
        public string[] SelectedRoles { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        public string UserFirstName { get; set; }

        [Display(Name = "Kullanıcı Soyadı")]
        public string UserLastName { get; set; }

    }
}
