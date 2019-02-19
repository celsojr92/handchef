using HandChef.Shared.Classes;
using System;
using System.Collections.Generic;

namespace HandChef.Domain.Entities
{
    public class Recipe : Entity
    {
        public string Title { get; private set; }
        public IList<RecipeIngridient> Ingredients { get; private set; }
        public string Directions { get; private set; }
    }
}
