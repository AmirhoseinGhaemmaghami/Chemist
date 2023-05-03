namespace Chemist.Api.Dto
{
    public class PizzaInputDto
    {
        public string Name { get; set; } = "";
        public int Count { get; set; }
        public List<string> Toppings { get; set; } = new List<string>();
    }
}
