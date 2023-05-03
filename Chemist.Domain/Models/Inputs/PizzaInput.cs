using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemist.Domain.Models.Inputs
{
    public class PizzaInput
    {
        public string Name { get; set; } = "";
        public int Count { get; set; }
        public List<string> Toppings { get; set; } = new List<string>();
    }
}