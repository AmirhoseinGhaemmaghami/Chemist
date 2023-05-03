using AutoMapper;
using Chemist.Api.Dto;
using Chemist.Domain.Models.Inputs;

namespace Chemist.Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PizzaInputDto, PizzaInput>();
        }
    }
}
