namespace CoffeeDispenser.API.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<DrinkIngredient> DrinkIngredients { get; set; }
 
    }
}
