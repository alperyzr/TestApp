using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using TestApp.Core.Application;
using TestApp.Core.Application.UrlShorts.Commands;
using TestApp.Core.Application.UrlShorts.ViewModels;
using TestApp.Core.Entities;
using TestApp.Repository;


namespace TestApp.API.Pipeline.UrlShorts.Handlers
{
    public class AddUrlShortHandler : IRequestHandler<AddUrlShortCommand, ServiceResult<UrlShortDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public AddUrlShortHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<UrlShortDto>> Handle(AddUrlShortCommand request, CancellationToken cancellationToken)
        {
            var checkDataUser = _context.Users.Find(request.UserId);

            if (checkDataUser == null)
                return ServiceResult<UrlShortDto>.WarningResult(null, "Kullanıcı Buluunamadı");

            UrlShort model = _mapper.Map<UrlShort>(request);
            model.CreatedDate = DateTime.Now;
            model.ToRedirectUrl = model.Url;

            model.ShortUrl = GenerateShortUrl(model.Url);
            var chechShortUrl = await _context.UrlShorts.Where(x => x.ShortUrl.Contains(model.ShortUrl)).ToListAsync();
            
            await _context.UrlShorts.AddAsync(model);
            await _context.SaveChangesAsync();
            return ServiceResult<UrlShortDto>.SuccessResult(_mapper.Map<UrlShortDto>(model));
        }


        public string GenerateShortUrl(string Url)
        {

            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@az";
            var randomString = new string(Enumerable.Repeat(chars, 8).Select(x => x[random.Next(x.Length)]).ToArray());

            return randomString;

            // var domainUrl = "https://localhost:7039";

            // return domainUrl + "/" + randomString;


        }


    }

}
