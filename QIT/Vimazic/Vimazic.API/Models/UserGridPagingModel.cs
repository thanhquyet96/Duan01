using EPS.TSC.Service.Dtos.User;
using EPS.Utils.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EPS.TSC.API.Models
{
    public class UserGridPagingModel : PagingParams<UserGridDto>
    {
        public string Username { get; set; }
        public int? UnitId { get; set; }
       
        public override List<Expression<Func<UserGridDto, bool>>> GetPredicates()
        {
            var predicates = base.GetPredicates();

            if (!string.IsNullOrEmpty(Username))
            {
                predicates.Add(x => x.Username.Contains(Username));
            }

            if (UnitId.HasValue)
            {
                predicates.Add(x => x.UnitId == UnitId.Value);
            }
            predicates.Add(x => x.DeletedUserId == null);
            return predicates;
        }
    }
}
