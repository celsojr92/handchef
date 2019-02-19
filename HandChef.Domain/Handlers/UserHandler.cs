using HandChef.Domain.Commands.Inputs;
using HandChef.Domain.Repositories;
using HandChef.Shared.Commands;
using HandChef.Shared.Entities;
using System.Threading.Tasks;

namespace HandChef.Domain.Handlers
{
    public class UserHandler : Notifiable, ICommandHandlerAsync<AddUserCommand>
    {
        private readonly IUserRepository _repository;

        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(AddUserCommand command)
        {
            var dataSource = await _repository.Add(command);
            return new GenericResult(dataSource);
        }

        public async Task<ICommandResult> Handle(EditUserCommand command)
        {
            var dataSource = await _repository.Edit(command);
            return new GenericResult(dataSource);
        }
    }
}
