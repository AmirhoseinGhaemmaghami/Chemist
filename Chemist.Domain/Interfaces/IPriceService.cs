using Chemist.Domain.Models;
using Chemist.Domain.Models.Inputs;

namespace Chemist.Domain.Interfaces
{
    public interface IPriceService
    {
        decimal GetTotal(List<PizzaInput> pizzaInputs, Pizzeria pizzeria);
    }
}