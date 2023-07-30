using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Core.Application;
using TestApp.Core.Application.UrlShorts.Queries;
using TestApp.Core.Application.UrlShorts.ViewModels;
using TestApp.Core.Application.UserRoles.Queries;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UrlShorts.Handlers
{  

    public class GetUrlShortByIdHandler : IRequestHandler<GetUrlShortByIdQuery, ServiceResult<GetUrlShortByIdDto>>
    {
        private readonly AppDbContext _comtext;
        private readonly IMapper _mapper;

        public GetUrlShortByIdHandler(AppDbContext comtext, IMapper mapper)
        {
            _comtext = comtext;
            _mapper = mapper;
        }
      
        public async Task<ServiceResult<GetUrlShortByIdDto>> Handle(GetUrlShortByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _comtext.UrlShorts.Include(x => x.User).Select(x=> new GetUrlShortByIdDto
            {
                Id = x.Id,
                ShortUrl = x.ShortUrl,
                Url = x.Url,
                UserId = x.UserId,
                UserName = x.User.FirstName + " " + x.User.LastName,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                RedirectUrlDate = x.RedirectUrlDate,    
                ToRedirectUrl = x.ToRedirectUrl,
                UpdatedDate = x.UpdatedDate
            }).FirstOrDefaultAsync(x => x.Id == request.Id);

            if (model == null)
                return ServiceResult<GetUrlShortByIdDto>.WarningResult(null, "Kayıt bulunamadı");
            
            var response = _mapper.Map<GetUrlShortByIdDto>(model);
            return ServiceResult<GetUrlShortByIdDto>.SuccessResult(response);
		}
    }
}
