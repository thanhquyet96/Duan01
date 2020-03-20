using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EPS.TSC.Data.Entities;
using EPS.TSC.Service.Dtos.User;
using System.Linq;

namespace EPS.TSC.Service.Profiles
{
    public class UserDtoToEntity : DtoToEntity
    {
        public UserDtoToEntity()
        {
            CreateMap<UserCreateDto, USER>();
            CreateMap<UserUpdateDto, USER>();
        }
    }

    public class UserEntityToDto : EntityToDto
    {
        public UserEntityToDto()
        {
            CreateMap<USER, UserGridDto>()
                .ForMember(dest => dest.Roles, mo => mo.MapFrom(src => src.USER_ROLES.Select(x => x.ROLE.NAME)));
            CreateMap<USER, UserDetailDto>()
                .ForMember(dest => dest.RoleIds, mo => mo.MapFrom(src => src.USER_ROLES.Select(x => x.ROLE_ID)))
                .ForMember(dest => dest.RoleNames, mo => mo.MapFrom(src => src.USER_ROLES.Select(x => x.ROLE.NAME)));
            CreateMap<USER_PRIVILEGE, UserPrivilegeDto>();

        }
    }
}
