using AutoMapper;
using MediatR;
using TestApp.Core.Application.UrlShorts.Commands;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.UrlShorts.Handlers
{  
    public class AddUrlShortHandler : IRequestHandler<AddUrlShortCommand, int>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AddUrlShortHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddUrlShortCommand request, CancellationToken cancellationToken)
        {
            var checkDataUser = _context.Users.Find(request.UserId);
            
            if (checkDataUser == null)
                return 0;

            UrlShort model = _mapper.Map<UrlShort>(request);
            await _context.UrlShorts.AddAsync(model);
            await _context.SaveChangesAsync();
            return model.Id;
        }
    }
}
