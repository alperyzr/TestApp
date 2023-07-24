using AutoMapper;
using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.UrlShorts.Commands;
using TestApp.Core.Application.UrlShorts.Queries;
using TestApp.Core.Application.UrlShorts.ViewModels;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UrlShorts.Handlers
{
    public class GetUrlShortInfoByShortUrlHandler : IRequestHandler<GetUrlShortInfoByShortUrlQuery, ServiceResult<UrlShortDto>>
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public GetUrlShortInfoByShortUrlHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<UrlShortDto>> Handle(GetUrlShortInfoByShortUrlQuery request, CancellationToken cancellationToken)
        {
           
            var model = _context.UrlShorts.Where(x => x.ShortUrl == request.ShortUrl).FirstOrDefault();

            if (model == null)
                return ServiceResult<UrlShortDto>.WarningResult(null, "Short Url Buluunamadı");


            return ServiceResult<UrlShortDto>.SuccessResult(_mapper.Map<UrlShortDto>(model));
        }
    }
}
