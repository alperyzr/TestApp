﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Core.Application;
using TestApp.Core.Application.UserRoles.Commands;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UserRoles.Handlers
{
    public class AddUserRoleHandler : IRequestHandler<AddUserRoleCommand, ServiceResult<UserRoleDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AddUserRoleHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<UserRoleDto>> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            var checkDataUser = await _context.Users.FindAsync(request.UserId);
            var checkDataRole = await _context.Roles.FindAsync(request.RoleId);
            if (checkDataUser == null && checkDataRole == null)
                ServiceResult<UserRoleDto>.WarningResult(null, "Kullanıcı ve ya Rol bulunamadı.", "400");

            UserRole model = _mapper.Map<UserRole>(request);
            var userRoles = await _context.UserRoles.Where(x => x.UserId == model.UserId).ToListAsync();
            foreach (var item in userRoles)
            {
                _context.Remove(item);
            }
            
            await _context.SaveChangesAsync();

            foreach (var item in request.SelectedRoles)
            {               
                await _context.UserRoles.AddAsync(new UserRole
                {
                    CreatedDate = DateTime.Now,
                    IsActive = model.IsActive,
                    IsDeleted = model.IsDeleted,
                    UpdatedDate = model.UpdatedDate,
                    UserId = model.UserId,
                    RoleId = Convert.ToInt32(item)
                    
                });
            }
            
            await _context.SaveChangesAsync();
            return ServiceResult<UserRoleDto>.SuccessResult(_mapper.Map<UserRoleDto>(model));
        }
    }
}
