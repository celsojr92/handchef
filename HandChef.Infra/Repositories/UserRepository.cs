using Dapper;
using HandChef.Domain.Commands.Inputs;
using HandChef.Domain.Repositories;
using OT.Hub.Infra.Contexts;
using System.Threading.Tasks;

namespace HandChef.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDataContext _context;

        public UserRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(AddUserCommand command)
        {
            var selector = @"
                insert into user (
                  name,
                  email,
                  password)
                values (
                  @name,
                  @email,
                  @password)
            ";

            var rows = await _context.Connection.ExecuteAsync(selector, command);

            return rows > 0;
        }

        public async Task<bool> Edit(EditUserCommand command)
        {
            var selector = @"
                update 
                  user
                set
                  name = @name
                where
                  userid = @userid
            ";

            var rows = await _context.Connection.ExecuteAsync(selector, command);

            return rows > 0;
        }
    }
}
