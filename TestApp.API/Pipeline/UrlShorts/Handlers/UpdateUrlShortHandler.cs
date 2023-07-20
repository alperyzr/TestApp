using AutoMapper;
using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.UrlShorts.Commands;
using TestApp.Core.Application.UrlShorts.ViewModels;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UrlShorts.Handlers
{
    public class UpdateUrlShortHandler : IRequestHandler<UpdateUrlShortCommand, ServiceResult<UrlShortDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateUrlShortHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<UrlShortDto>> Handle(UpdateUrlShortCommand request, CancellationToken cancellationToken)
        {
            var chechUser = await _context.Users.FindAsync(request.UserId);
           
            if (chechUser == null )
                return ServiceResult<UrlShortDto>.WarningResult(null, "Kullanıcı Bulunamadı");


            request.UpdatedDate = DateTime.Now;
            _context.UrlShorts.Update(_mapper.Map<UrlShort>(request));
            await _context.SaveChangesAsync();
            return ServiceResult<UrlShortDto>.SuccessResult(_mapper.Map<UrlShortDto>(request));
        }
    }
}
