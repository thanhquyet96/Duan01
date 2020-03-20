using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EPS.TSC.Data.Entities;
using EPS.TSC.Service.Dtos.Role;
using System.Linq;

namespace EPS.TSC.Service.Profiles
{
    public class RoleDtoToEntity : DtoToEntity
    {
        public RoleDtoToEntity()
        {
            CreateMap<RoleCreateDto, ROLE>();
            CreateMap<RoleUpdateDto, ROLE>();
            CreateMap<ExploitationRoleCreateDto, ROLE>();
        }
    }

    public class RoleEntityToDto : EntityToDto
    {
        public RoleEntityToDto()
        {
            CreateMap<ROLE, RoleGridDto>();
            CreateMap<ROLE, RoleDetailDto>();
            CreateMap<ROLE_PRIVILEGE, RolePrivilegeDto>();
        }
    }
}
