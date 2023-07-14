using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Core.Application.UrlShorts.Queries;
using TestApp.Core.Application.UrlShorts.ViewModels;
using TestApp.Core.Application.UserRoles.Queries;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UrlShorts.Handlers
{  

    public class GetUrlShortByIdHandler : IRequestHandler<GetUrlShortByIdQuery, GetUrlShortByIdDto>
    {
        private readonly AppDbContext _comtext;
        private readonly IMapper _mapper;

        public GetUrlShortByIdHandler(AppDbContext comtext, IMapper mapper)
        {
            _comtext = comtext;
            _mapper = mapper;
        }
      
        public async Task<GetUrlShortByIdDto> Handle(GetUrlShortByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _comtext.UrlShorts.Include(x => x.User).Select(x=> new GetUrlShortByIdDto
            {
                Id = x.Id,
                UrlKey = x.UrlKey,
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

            var response = _mapper.Map<GetUrlShortByIdDto>(model);
            return response;
        }
    }
}
