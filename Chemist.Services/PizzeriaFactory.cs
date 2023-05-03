using Chemist.Domain.Interfaces;
using Chemist.Domain.Models;

namespace Chemist.Services
{
    public class PizzeriaFactory : IPizzeriaFactory
    {
        public Pizzeria CreatePizzeria(string location)
        {
            switch (location)
            {
                case "Preston":
                    return CreatePrestonPizzeria();
                case "Southbank":
                    return CreateSouthbankPizzeria();
                default:
                    throw new Exception("Unkonow pizzeria");
            }
        }

        private Pizzeria CreatePrestonPizzeria()
        {
            var capricciosa = new MenuItem()
            {
                Name = "Capricciosa",
                Ingredients = new List<string>(new string[] { "Cheese", "Ham", "Mushrooms", "Olives" }),
                Price = 20
            };
            var mexicana = new MenuItem()
            {
                Name = "Mexicana",
                Ingredients = new List<string>(new string[] { "Cheese", "Salami", "Capsicum", "Chilli" }),
                Price = 18
            };
            var margherita = new MenuItem()
            {
                Name = "Margherita",
                Ingredients = new List<string>(new string[] { "Cheese", "Spinach", "Ricotta", "Cherry Tomatoes" }),
                Price = 22
            };

            Menu menu = new Menu()
            {
                MenuItems = new List<MenuItem>(new MenuItem[] { capricciosa, mexicana, margherita })
            };

            return new Pizzeria()
            {
                Location = "Preston",
                Menu = menu
            };
        }

        private Pizzeria CreateSouthbankPizzeria()
        {
            var capricciosa = new MenuItem()
            {
                Name = "Capricciosa",
                Ingredients = new List<string>(new string[] { "Cheese", "Ham", "Mushrooms", "Olives" }),
                Price = 25
            };
            var vegetarian = new MenuItem()
            {
                Name = "Vegetarian",
                Ingredients = new List<string>(new string[] { "Cheese", "Mushrooms", "Capsicum", "Onion", "Olives" }),
                Price = 17
            };

            Menu menu = new Menu()
            {
                MenuItems = new List<MenuItem>(new MenuItem[] { capricciosa, vegetarian })
            };

            return new Pizzeria()
            {
                Location = "Southbank",
                Menu = menu
            };
        }
    }
}