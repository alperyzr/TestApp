using Bentas.O2.DynamicLinq;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Application.Login.Queries;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;

namespace TestApp.Service
{
	public static class ApiClient
	{
        #region Login
        public static string Login = "login/login";
        #endregion

        #region User
        public static string AddUser = "user/AddUser";
		public static string UpdateUser = "user/UpdateUser";
		public static string DeleteUser = "user/DeleteUser";
		public static string GetUserById = "user/GetUserById";
		public static string ListDsUser = "user/listDs";
		public static string GetAllUsers = "user/GetAllUsers";
        #endregion

        #region Role
        public static string AddRole = "role/AddRole";
        public static string UpdateRole = "role/UpdateRole";
        public static string DeleteRole = "role/DeleteRole";
        public static string GetRoleById = "role/GetRoleById";
        public static string ListDsRole = "role/listDs";
        #endregion

        #region UserRole
        public static string AddUserRole = "userrole/AddUserRole";
        public static string UpdateUserRole = "userrole/UpdateUserRole";
        public static string DeleteUserRole = "userrole/DeleteUserRole";
        public static string GetUserRoleById = "userrole/GetUserRoleById";
        public static string ListDsUserRole = "userrole/listDs";
        #endregion

        #region UrlShort
        public static string AddUrlShort = "urlshort/AddUrlShort";
        public static string UpdateUrlShort = "urlshort/UpdateUrlShort";
        public static string DeleteUrlShort = "urlshort/DeleteUrlShort";
        public static string GetUrlShortById = "urlshort/GetUrlShortById";
        public static string ListDsUrlShortr = "urlshort/listDs";
        #endregion

    }
}
