using AutoMapper;
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
            if (checkDataUser == null)
                return ServiceResult<UserRoleDto>.WarningResult(null, "Kullanıcı bulunamadı.");

            if (request.SelectedRoles == null || request.SelectedRoles.Count() == 0)
                return ServiceResult<UserRoleDto>.WarningResult(null, "Rol Seçilmesi Zorunludur.");

            UserRole model = _mapper.Map<UserRole>(request);
            

            foreach (var item in request.SelectedRoles)
            {               
                await _context.UserRoles.AddAsync(new UserRole
                {
                    IsActive = model.IsActive,
                    CreatedDate = DateTime.Now,
                    IsDeleted = model.IsDeleted,
                    UpdatedDate = model.UpdatedDate,
                    UserId = model.UserId,
                    RoleId = Convert.ToInt32(item)
                    
                });
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ServiceResult<UserRoleDto>.ErrorResult(null,"Her Kullanıcıda Seçilen Rol Bir Defa Eklenebilir.");
            }
            
            return ServiceResult<UserRoleDto>.SuccessResult(_mapper.Map<UserRoleDto>(model));
        }
    }
}
