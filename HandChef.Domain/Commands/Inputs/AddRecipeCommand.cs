using HandChef.Domain.Entities;
using HandChef.Shared.Commands;
using System.Collections.Generic;

namespace HandChef.Domain.Commands.Inputs
{
    public class AddRecipeCommand : ICommand
    {
        public string Title { get; set; }
        public IList<RecipeIngridient> Ingredients { get; set; }
        public string Directions { get; set; }
    }
}
