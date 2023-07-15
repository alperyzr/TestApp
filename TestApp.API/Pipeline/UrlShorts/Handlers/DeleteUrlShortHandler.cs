using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.UrlShorts.Commands;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UrlShorts.Handlers
{
    public class DeleteUrlShortHandler : IRequestHandler<DeleteUrlShortCommand, ServiceResult<Unit>>
    {
        private readonly AppDbContext _context;

        public DeleteUrlShortHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<Unit>> Handle(DeleteUrlShortCommand request, CancellationToken cancellationToken)
        {
            var model = _context.UrlShorts.FirstOrDefault(x => x.Id == request.Id);

            if (model == null)
                return ServiceResult<Unit>.WarningResult(Unit.Value,"Kayıt bulunamadı");

            _context.Remove(model);
            await _context.SaveChangesAsync();
            return ServiceResult<Unit>.SuccessResult(Unit.Value);

        }
    }
}
