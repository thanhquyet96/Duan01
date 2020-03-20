using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace EPS.Utils.Repository.Audit
{
    public interface IUserIdentity<TUserKey> where TUserKey : struct
    {
        TUserKey UserId { get; }
        string Username { get; }
        List<string> Privileges { get; }
        bool IsAdministrator { get; }
        int UnitId { get; }
    }
}
