using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Entities;

namespace TestApp.Core.Application.UserRoles.ViewModels
{
    public class GetUserRoleByIdDto : _BaseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }       
        public string UserName { get; set; }
        public string RoleName { get; set; }

    }
}
