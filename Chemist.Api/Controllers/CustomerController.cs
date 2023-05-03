using AutoMapper;
using Chemist.Api.Dto;
using Chemist.Domain.Interfaces;
using Chemist.Domain.Models.Inputs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chemist.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IPizzeriaFactory pizzeriaFactory;
        private readonly IPriceService priceService;
        private readonly IMapper mapper;

        public CustomerController(IPizzeriaFactory pizzeriaFactory, IPriceService priceService,
            IMapper mapper)
        {
            this.pizzeriaFactory = pizzeriaFactory;
            this.priceService = priceService;
            this.mapper = mapper;
        }

        [HttpPost("{location}")]
        public ActionResult<decimal> GetTotalPrice(string location, List<PizzaInputDto> pizzaInputs)
        {
            var pizzeria = this.pizzeriaFactory.CreatePizzeria(location);
            return this.priceService.GetTotal(mapper.Map<List<PizzaInput>>(pizzaInputs), pizzeria);
        }
    }
}
