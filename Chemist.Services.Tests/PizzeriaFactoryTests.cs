using Chemist.Domain.Models;

namespace Chemist.Services.Tests
{
    public class PizzeriaFactoryTests
    {
        private readonly PizzeriaFactory _factory;
        public PizzeriaFactoryTests()
        {
            _factory = new PizzeriaFactory();
        }
        [Fact]
        public void CreatePizzeria_ReturnsPrestonPizzeria_WhenLocationIsPreston()
        {
            // Act
            var pizzeria = _factory.CreatePizzeria("Preston");

            // Assert
            Assert.Equal("Preston", pizzeria.Location);
            Assert.Equal(3, pizzeria.Menu.MenuItems.Count);
            Assert.Collection(pizzeria.Menu.MenuItems,
                item => Assert.Equal("Capricciosa", item.Name),
                item => Assert.Equal("Mexicana", item.Name),
                item => Assert.Equal("Margherita", item.Name));
        }

        [Fact]
        public void CreatePizzeria_ReturnsSouthbankPizzeria_WhenLocationIsSouthbank()
        {
            // Act
            var pizzeria = _factory.CreatePizzeria("Southbank");

            // Assert
            Assert.Equal("Southbank", pizzeria.Location);
            Assert.Equal(2, pizzeria.Menu.MenuItems.Count);
            Assert.Collection(pizzeria.Menu.MenuItems,
                item => Assert.Equal("Capricciosa", item.Name),
                item => Assert.Equal("Vegetarian", item.Name));
        }

        [Fact]
        public void CreatePizzeria_ThrowsException_WhenLocationIsUnknown()
        {
            // Act & Assert
            Assert.Throws<Exception>(() => _factory.CreatePizzeria("Unknown"));
        }
    }
}