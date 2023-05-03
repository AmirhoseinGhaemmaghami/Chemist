namespace Chemist.Domain.Models
{
    public class MenuItem
    {
        public string Name { get; set; } = "";
        public List<string> Ingredients { get; set; } = new List<string>();
        public decimal Price { get; set; }
    }
}