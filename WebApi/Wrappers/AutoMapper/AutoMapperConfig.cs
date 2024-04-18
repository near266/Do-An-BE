using AutoMapper;
using WebApi.Application.Models.Dtos;
using WebApi.Wrappers.DTOS;

namespace WebApi.Wrappers.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        { 
            CreateMap<RegisterSale, TeleSaleDTO>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));

        }
    }
}
