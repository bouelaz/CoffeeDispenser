namespace CoffeeDispenser.API.Dtos
{
    public class IngredientDto
    { 
        public string Name { get; set; } 
        public int Units { get; internal set; }
        public decimal PricePerUnit { get; internal set; }
    }
}