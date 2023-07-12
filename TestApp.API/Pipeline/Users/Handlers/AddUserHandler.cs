using AutoMapper;
using MediatR;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Entities;
using TestApp.Core.Models;
using TestApp.Repository;

namespace TestApp.API.Pipeline.Users.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, int>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AddUserHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var checkData = _context.Users.FirstOrDefault(x => x.Email == request.Email);
            if (checkData != null)
                return 0;
            
            User model = _mapper.Map<User>(request);
            await _context.Users.AddAsync(model);
            await _context.SaveChangesAsync();
            return model.Id;
        }
    }
}
