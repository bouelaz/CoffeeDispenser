namespace CoffeeDispenser.API.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerUnit { get; set; }
        public ICollection<DrinkIngredient> DrinkIngredients { get; set; }
    }
}

