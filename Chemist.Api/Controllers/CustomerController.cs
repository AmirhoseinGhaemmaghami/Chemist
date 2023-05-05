using AutoMapper;
using Chemist.Api.Dto;
using Chemist.Api.Helpers;
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
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<decimal> GetTotalPrice(string location, List<PizzaInputDto> pizzaInputs)
        {
            try
            {
                var pizzeria = this.pizzeriaFactory.CreatePizzeria(location);
                return ApiResponse.Ok(this.priceService.GetTotal(mapper.Map<List<PizzaInput>>(pizzaInputs), pizzeria));
            }
            catch (Exception ex)
            {
                return ApiResponse.BadRequest(ex.Message);
            }
        }
    }
}
