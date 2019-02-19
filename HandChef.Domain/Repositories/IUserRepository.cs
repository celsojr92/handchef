using HandChef.Domain.Commands.Inputs;
using System.Threading.Tasks;

namespace HandChef.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<bool> Add(AddUserCommand user);
        Task<bool> Edit(EditUserCommand user);
    }
}
