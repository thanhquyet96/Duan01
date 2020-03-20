using EPS.TSC.Data.Entities;
using EPS.Utils.Repository;
using EPS.Utils.Repository.Audit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPS.TSC.Data
{
    public class TSCRepository : Repository<TSCContext, USER, int>
    {
        public TSCRepository(TSCContext dbContext, IUserIdentity<int> currentUser, ILogger<TSCRepository> logger) : base(dbContext, currentUser, logger)
        {

        }
    }
}
