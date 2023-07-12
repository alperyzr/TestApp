using AutoMapper;
using MediatR;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Entities;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Users.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateUserHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User model = _mapper.Map<User>(request);
            model.Id = request.Id;

            _context.Users.Update(model);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
