using AutoMapper;
using MediatR;
using TestApp.Core.Application.Roles.Commands;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Roles.Handlers
{
    public class AddRoleHandler : IRequestHandler<AddRoleCommand, int>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AddRoleHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var checkData = _context.Roles.FirstOrDefault(x => x.Name == request.Name);
            if (checkData != null)
                return 0;

            Role model = _mapper.Map<Role>(request);
            await _context.Roles.AddAsync(model);
            await _context.SaveChangesAsync();
            return model.Id;
        }
    }
}
