
using MediatR;
using TestApp.Core.Application;
using TestApp.MVC.Services.Interfaces;
using TestApp.Service;
using TestApp.MVC.Extentions;
using TestApp.Core.Application.UrlShorts.ViewModels;
using TestApp.Core.Application.UrlShorts.Commands;
using TestApp.Core.Application.UrlShorts.Queries;

namespace TestApp.MVC.Services
{
   
    public class UrlShortService : IUrlShortService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private string ApiUrl => _configuration["ApiUrl"];

        public UrlShortService(HttpClient httpClient,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResult<UrlShortDto>> AddUrlShort(AddUrlShortCommand req)
        {
            var model = await _httpClient.CustomPostAsync<ServiceResult<UrlShortDto>>($"{ApiUrl}/{ApiClient.AddUrlShort}", req);
            return model;
        }

        public async Task<ServiceResult<Unit>> DeleteUrlShort(int Id, DeleteUrlShortCommand req)
        {
            var model = await _httpClient.CustomDeleteAsync<ServiceResult<Unit>>($"{ApiUrl}/{ApiClient.DeleteUrlShort}/" + req.Id, req);
            return model;
        }

        public async Task<ServiceResult<UrlShortDto>> GetUrlShortById(GetUrlShortByIdQuery req)
        {
            var model = await _httpClient.CustomGetAsync<ServiceResult<UrlShortDto>>($"{ApiUrl}/{ApiClient.GetUrlShortById}/" + req.Id, req);
            return model;
        }

        public async Task<ListDsUrlShortView> ListDsUrlShortQuery(ListDsUrlShortQuery req)
        {
            var model = await _httpClient.CustomPostAsync<ListDsUrlShortView>($"{ApiUrl}/{ApiClient.ListDsUrlShort}", req);
            return model;
        }

        public async Task<ServiceResult<UrlShortDto>> UpdateUrlShort(int Id, UpdateUrlShortCommand req)
        {
            var model = await _httpClient.CustomPutAsync<ServiceResult<UrlShortDto>>($"{ApiUrl}/{ApiClient.UpdateUrlShort}/" + req.Id, req);
            return model;
        }

        public async Task<ServiceResult<List<UrlShortDto>>> GetAllUrlShorts(GetAllUrlShortsQuery req)
        {
            var model = await _httpClient.CustomGetAsync<ServiceResult<List<UrlShortDto>>>($"{ApiUrl}/{ApiClient.GetAllUrlShorts}", req);
            return model;
        }

        public async Task<ServiceResult<UrlShortDto>> GetUrlShortInfoByShortUrl(GetUrlShortInfoByShortUrlQuery req)
        {
            var model = await _httpClient.CustomGetAsync<ServiceResult<UrlShortDto>>($"{ApiUrl}/{ApiClient.GetUrlShortInfoByShortUrl}", req);
            return model;
        }
    }
}
