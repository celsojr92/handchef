using HandChef.Domain.Commands.Inputs;
using System.Threading.Tasks;

namespace HandChef.Domain.Repositories
{
    public interface IRecipeRepository
    {
        Task<bool> Add(AddRecipeCommand recipe);
    }
}
