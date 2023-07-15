using AutoMapper;
using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.UrlShorts.Commands;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UrlShorts.Handlers
{
    public class UpdateUrlShortHandler : IRequestHandler<UpdateUrlShortCommand, ServiceResult<Unit>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateUrlShortHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<Unit>> Handle(UpdateUrlShortCommand request, CancellationToken cancellationToken)
        {
            UrlShort model = _mapper.Map<UrlShort>(request);
            model.Id = request.Id;

            var chechData = await _context.UrlShorts.FindAsync(model.Id);
            if (chechData == null)
				return ServiceResult<Unit>.WarningResult(Unit.Value,"Kayıt bulunamadı");


			_context.UrlShorts.Update(model);
            await _context.SaveChangesAsync();
            return ServiceResult<Unit>.SuccessResult(Unit.Value);
        }
    }
}
