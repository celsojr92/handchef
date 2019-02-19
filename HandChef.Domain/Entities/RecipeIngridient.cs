using HandChef.Domain.Enums;

namespace HandChef.Domain.Entities
{
    public class RecipeIngridient
    {
        public int Amount { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }
        public Ingredient Ingredient { get; set; }
        public long RecipeId { get; set; }
    }
}
