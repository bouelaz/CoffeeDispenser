namespace CoffeeDispenser.API.Dtos
{
    public class DrinkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal TotalCost { get;  set; }
        public List<IngredientDto> Ingredients { get; set; }
    }
}
