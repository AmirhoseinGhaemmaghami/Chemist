using Chemist.Domain.Interfaces;
using Chemist.Domain.Models;
using Chemist.Domain.Models.Inputs;
using Moq;

namespace Chemist.Services.Tests
{
    public class PriceServiceTests
    {
        private readonly PriceService _priceService;

        public PriceServiceTests()
        {
            _priceService = new PriceService();
        }


        #region ToppingPrice Tests

        [Fact]
        public void GetToppingPrice_NullToppings_ReturnsZero()
        {
            // Arrange
            List<string> toppings = null;

            // Act
            decimal result = _priceService.GetToppingPrice(toppings);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void GetToppingPrice_EmptyToppings_ReturnsZero()
        {
            // Arrange
            List<string> toppings = new List<string>();

            // Act
            decimal result = _priceService.GetToppingPrice(toppings);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void GetToppingPrice_ValidToppings_ReturnsCount()
        {
            // Arrange
            List<string> toppings = new List<string>() { "Cheese", "Capsicum", "Salami" };

            // Act
            decimal result = _priceService.GetToppingPrice(toppings);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void GetToppingPrice_InvalidToppings_ThrowsException()
        {
            // Arrange
            List<string> toppings = new List<string>() { "Cheese", "Capsicum", "Salami", "InvalidTopping" };

            // Act & Assert
            Exception ex = Assert.Throws<Exception>(() => _priceService.GetToppingPrice(toppings));
            Assert.Equal("Invalid Topping", ex.Message);
        }

        #endregion

        #region PizzaPrice Tests
        [Fact]
        public void GetPizzaPrice_ValidPizza_ReturnsCorrectPrice()
        {
            // Arrange
            var pizzeria = new Pizzeria
            {
                Menu = new Menu
                {
                    MenuItems = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Name = "Margarita",
                        Price = 10
                    },
                    new MenuItem
                    {
                        Name = "Pepperoni",
                        Price = 12
                    }
                }
                }
            };

            // Act
            var margaritaPrice = _priceService.GetPizzaPrice(pizzeria, "Margarita");

            // Assert
            Assert.Equal(10, margaritaPrice);
        }

        [Fact]
        public void GetPizzaPrice_InvalidPizzaName_ThrowsException()
        {
            // Arrange
            var pizzeria = new Pizzeria
            {
                Menu = new Menu
                {
                    MenuItems = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Name = "Margarita",
                        Price = 10
                    },
                    new MenuItem
                    {
                        Name = "Pepperoni",
                        Price = 12
                    }
                }
                }
            };

            // Act and Assert
            Assert.Throws<Exception>(() => _priceService.GetPizzaPrice(pizzeria, "Hawaiian"));
        }

        [Fact]
        public void GetPizzaPrice_NullPizzeria_ThrowsException()
        {
            // Act and Assert
            Assert.Throws<NullReferenceException>(() => _priceService.GetPizzaPrice(null, "Margarita"));
        }
        #endregion

        #region TotalPrice Tests
        [Fact]
        public void GetTotal_Returns_Correct_Total_Price()
        {
            // Arrange
            var pizzaInputs = new List<PizzaInput>
        {
            new PizzaInput { Name = "Margherita", Toppings = new List<string> { "Cheese" } },
            new PizzaInput { Name = "Pepperoni", Toppings = new List<string> { "Cheese", "Capsicum" } }
        };
            var pizzeria = new Pizzeria
            {
                Menu = new Menu
                {
                    MenuItems = new List<MenuItem>
                {
                    new MenuItem { Name = "Margherita", Price = 10 },
                    new MenuItem { Name = "Pepperoni", Price = 12 }
                }
                }
            };

            // Act
            var result = _priceService.GetTotal(pizzaInputs, pizzeria);

            // Assert
            Assert.Equal(25, result);
        }
        #endregion
    }
}