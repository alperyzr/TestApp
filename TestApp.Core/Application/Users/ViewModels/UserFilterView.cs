using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Core.Application.Users.ViewModels
{
	public class UserFilterView
	{
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
