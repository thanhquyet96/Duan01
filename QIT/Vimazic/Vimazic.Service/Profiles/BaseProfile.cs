using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPS.TSC.Service.Profiles
{
    public abstract class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            SourceMemberNamingConvention = new PascalCaseNamingConvention();
            DestinationMemberNamingConvention = new UpperUnderscoreNamingConvention();
        }
    }

    public abstract class EntityToDto : Profile
    {
        public EntityToDto()
        {
            SourceMemberNamingConvention = new UpperUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
        }
    }
}
