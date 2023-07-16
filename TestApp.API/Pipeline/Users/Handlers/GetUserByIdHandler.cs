using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Core.Application;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Users.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ServiceResult<UserDto>>
    {
        private readonly AppDbContext _comtext;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(AppDbContext comtext, IMapper mapper)
        {
            _comtext = comtext;
            _mapper = mapper;
        }
        public async Task<ServiceResult<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
           
            var model = await _comtext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (model == null)
                return ServiceResult<UserDto>.WarningResult(null, "Kullanıcı Bulunamadı");

            return ServiceResult<UserDto>.SuccessResult(_mapper.Map<UserDto>(model));
        }
    }
}
