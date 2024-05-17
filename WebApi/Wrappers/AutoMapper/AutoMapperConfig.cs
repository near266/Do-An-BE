using AutoMapper;
using WebApi.Application.Models.Dtos.EnterpriseDTO;
using WebApi.Application.Models.Dtos.Userinfo;
using WebApi.Modules.Dtos;
using WebApi.Wrappers.DTOS;
using WebApi.Wrappers.DTOS.UserInfoDtos;

namespace WebApi.Wrappers.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RegisterUserInfo, UserInfoDTO>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<RegisterUserInfo, UserDtos>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<RegisterEnterprise, UserDtos>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<RegisterEnterprise, EnterpriseDTO>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<UpdateEnterpiseRequest, EnterpriseDTO>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<UpdateInfoEnterprise, EnterpriseDTO>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));


        }
    }
}
