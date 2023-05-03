using System.ComponentModel.Design;

namespace Chemist.Domain.Models
{
    public class Pizzeria
    {
        public string Location { get; set; } = "";
        public Menu Menu { get; set; } = new Menu();
    }
}