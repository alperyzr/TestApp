using AutoMapper;
using MediatR;
using TestApp.Core.Application.UrlShorts.Commands;
using TestApp.Core.Application.UrlShorts.ViewModels;
using TestApp.Core.Application;
using TestApp.Core.Entities;
using TestApp.Repository;
using TestApp.Core.Application.UrlShorts.Queries;
using Microsoft.EntityFrameworkCore;
using TestApp.Core.Application.Roles.ViewModels;

namespace TestApp.API.Pipeline.UrlShorts.Handlers
{
    public class GetAllUrlShortsHandler : IRequestHandler<GetAllUrlShortsQuery, ServiceResult<List<UrlShortDto>>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public GetAllUrlShortsHandler(AppDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ServiceResult<List<UrlShortDto>>> Handle(GetAllUrlShortsQuery request, CancellationToken cancellationToken)
        {
            var path = _configuration.GetValue<string>("ClientUrl");

            var response = await _context.UrlShorts.Include(x=>x.User).OrderByDescending(x => x.Id).Select(x=> new UrlShortDto
            {
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Id = x.Id,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                RedirectUrlDate = x.RedirectUrlDate,
                ToRedirectUrl = x.ToRedirectUrl,
                UpdatedDate = x.UpdatedDate,
                Url = x.Url,
                ShortUrl = $"{path}{x.ShortUrl}",
                UserName = x.User.FirstName + " " + x.User.LastName,
                UserId = x.UserId
            }).ToListAsync();
            return ServiceResult<List<UrlShortDto>>.SuccessResult(_mapper.Map<List<UrlShortDto>>(response));
        }

        
    }
}
