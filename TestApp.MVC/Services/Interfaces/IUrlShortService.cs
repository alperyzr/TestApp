using Bentas.O2.DynamicLinq;
using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.UrlShorts.Commands;
using TestApp.Core.Application.UrlShorts.Queries;
using TestApp.Core.Application.UrlShorts.ViewModels;

namespace TestApp.MVC.Services.Interfaces
{
    public interface IUrlShortService
    {
        Task<ServiceResult<UrlShortDto>> AddUrlShort(AddUrlShortCommand req);
        Task<ServiceResult<Unit>> DeleteUrlShort(int Id, DeleteUrlShortCommand req);
        Task<ServiceResult<UrlShortDto>> UpdateUrlShort(int Id, UpdateUrlShortCommand req);
        Task<ServiceResult<UrlShortDto>> GetUrlShortById(GetUrlShortByIdQuery req);
        Task<BDataSourceResult<ListDsUrlShortView>> ListDsUrlShortQuery(ListDsUrlShortQuery req);
        Task<ServiceResult<List<UrlShortDto>>> GetAllUrlShorts(GetAllUrlShortsQuery req);
        Task<ServiceResult<UrlShortDto>> GetUrlShortInfoByShortUrl(GetUrlShortInfoByShortUrlQuery req);
    }
}
