using Chemist.Domain.Interfaces;
using Chemist.Domain.Models;
using Chemist.Domain.Models.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemist.Services
{
    public class PriceService : IPriceService
    {
        public decimal GetTotal(List<PizzaInput> pizzaInputs, Pizzeria pizzeria)
        {
            decimal sum = 0;
            foreach (var pizza in pizzaInputs)
            {
                var pizzaPrice = GetPizzaPrice(pizzeria, pizza.Name);
                var ToppingPrice = GetToppingPrice(pizza.Toppings);
                sum += (pizzaPrice * pizza.Count + ToppingPrice);
            }
            return sum;
        }

        public decimal GetToppingPrice(List<string> toppings)
        {
            if (toppings == null)
            {
                return 0;
            }

            var validToppings = new String[] { "Cheese", "Capsicum", "Salami", "Olives" };
            if (toppings.All(t => validToppings.Select(s => s.ToUpper()).Contains(t.ToUpper())))
            {
                return toppings.Count();
            }
            else
            {
                throw new Exception("Invalid Topping");
            }
        }

        public decimal GetPizzaPrice(Pizzeria pizzeria, string pizzaName)
        {
            var upperCasePizzaName = pizzaName.ToUpper();
            var menuItem = pizzeria.Menu.MenuItems.FirstOrDefault(p => p.Name.ToUpper() == upperCasePizzaName);
            if (menuItem == null)
            {
                throw new Exception("Invalid Pizza has been Ordered");
            }

            return menuItem.Price;
        }
    }
}
