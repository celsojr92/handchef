using HandChef.Shared.Commands;
using System;

namespace HandChef.Domain.Commands.Inputs
{
    public class AddUserCommand : ICommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
