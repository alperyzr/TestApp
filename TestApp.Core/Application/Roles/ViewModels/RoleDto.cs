using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Core.Application.Roles.ViewModels
{
    public class RoleDto:_BaseDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Rol alanı boş geçilemez")]
        public string Name { get; set; }
    }
}
