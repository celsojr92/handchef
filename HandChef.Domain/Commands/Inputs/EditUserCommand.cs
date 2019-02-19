using HandChef.Shared.Commands;

namespace HandChef.Domain.Commands.Inputs
{
    public class EditUserCommand : ICommand
    {
        public long UserId { get; set; }
        public string Name { get; set; }
    }
}
