using AutoMapper;
using Bentas.O2.DynamicLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Application;
using TestApp.Core.Application.Roles.ViewModels;
using TestApp.Core.Application.UrlShorts.ViewModels;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Core.Entities;

namespace TestApp.Service.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<UserRole, UserRoleDto>().ReverseMap();
            CreateMap<UrlShort, UrlShortDto>().ReverseMap();            
            CreateMap<UserRoleDto, DropDownView>().ReverseMap();                                      
            CreateMap<ListDsUserView, User>().ReverseMap();                                      
            CreateMap<ListDsUserRoleView, UserRole>().ReverseMap();                                      
            CreateMap<ListDsRoleView, Role>().ReverseMap();                                      
            CreateMap<ListDsUrlShortView, UrlShort>().ReverseMap();                                      
            
        }
    }
}
