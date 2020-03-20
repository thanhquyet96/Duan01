using AutoMapper;
using EPS.TSC.Data;
using EPS.Utils.Service;
using System;

namespace EPS.TSC.Service
{
    public class TSCBaseService : BaseService
    {
        public TSCBaseService(TSCRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
