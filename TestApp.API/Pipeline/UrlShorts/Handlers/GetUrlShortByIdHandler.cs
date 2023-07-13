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

    public class GetUrlShortByIdHandler : IRequestHandler<GetUrlShortByIdQuery, UrlShortDto>
    {
        private readonly AppDbContext _comtext;
        private readonly IMapper _mapper;

        public GetUrlShortByIdHandler(AppDbContext comtext, IMapper mapper)
        {
            _comtext = comtext;
            _mapper = mapper;
        }
      
        public async Task<UrlShortDto> Handle(GetUrlShortByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _comtext.UrlShorts.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == request.Id);
            var response = _mapper.Map<UrlShortDto>(model);
            return response;
        }
    }
}
