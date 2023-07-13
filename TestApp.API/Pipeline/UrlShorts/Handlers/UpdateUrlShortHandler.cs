using AutoMapper;
using MediatR;
using TestApp.Core.Application.UrlShorts.Commands;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UrlShorts.Handlers
{
    public class UpdateUrlShortHandler : IRequestHandler<UpdateUrlShortCommand, Unit>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateUrlShortHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUrlShortCommand request, CancellationToken cancellationToken)
        {
            UrlShort model = _mapper.Map<UrlShort>(request);
            model.Id = request.Id;

            _context.UrlShorts.Update(model);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
