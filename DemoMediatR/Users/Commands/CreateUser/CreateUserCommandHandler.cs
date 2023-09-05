using DemoMediatR.Data;
using DemoMediatR.Interfaces;
using DemoMediatR.Models;
using MediatR;

namespace DemoMediatR.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IRepository<User> _repository;
        private readonly ApplicationDbContext _db;

        public CreateUserCommandHandler(IRepository<User> repository, ApplicationDbContext db) => (_repository, _db) = (repository, db);

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User()
            {
                Name = request.Name,
                Email = request.Email,
                RoleId = request.RoleId,
            };

            _repository.Create(user);
            _repository.SaveChangesAsync();

            return user;
        }
    }
}
