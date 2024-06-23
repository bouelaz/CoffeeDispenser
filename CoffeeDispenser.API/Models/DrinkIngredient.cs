namespace CoffeeDispenser.API.Models
{
    public class DrinkIngredient
    {
        public int DrinkId { get; set; }
        public Drink Drink { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        // Quantité de l'ingrédient en doses
        public int Quantity { get; set; } 
    }
}
