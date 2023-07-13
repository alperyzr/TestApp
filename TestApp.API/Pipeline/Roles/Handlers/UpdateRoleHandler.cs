using AutoMapper;
using MediatR;
using TestApp.Core.Application.Roles.Commands;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Roles.Handlers
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, Unit>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateRoleHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            Role model = _mapper.Map<Role>(request);
            model.Id = request.Id;

            _context.Roles.Update(model);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
