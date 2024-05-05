using AutoMapper;
using System.ComponentModel;
using System.Transactions;
using WebApi.Application.Models.Dtos.EnterpriseDTO;
using WebApi.Application.Models.Dtos.Userinfo;
using WebApi.Domain.Entites.Account;


namespace WebApi.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserInfoDTO, UserInfoDTO>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<userInfo, UserInfoDTO>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<userInfo, userInfo>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));

            CreateMap<enterprises, enterprises>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<enterprises, EnterpriseDTO>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));


        }

    }
}
