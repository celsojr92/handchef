using HandChef.Domain.Commands.Inputs;
using HandChef.Domain.Repositories;
using HandChef.Shared.Commands;
using HandChef.Shared.Entities;
using System.Threading.Tasks;

namespace HandChef.Domain.Handlers
{
    public class RecipeHandler : Notifiable, ICommandHandlerAsync<AddRecipeCommand>
    {
        private readonly IRecipeRepository _repository;

        public RecipeHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(AddRecipeCommand command)
        {
            var dataSource = await _repository.Add(command);
            return new GenericResult(dataSource);
        }
    }
}
