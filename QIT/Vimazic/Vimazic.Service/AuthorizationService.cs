using AutoMapper;
using EPS.TSC.Data;
using EPS.TSC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPS.TSC.Service
{
    public class AuthorizationService : TSCBaseService
    {
        public AuthorizationService(TSCRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public async Task<List<string>> GetUserPrivileges(int userId)
        {
            return await _repository.Filter<USER_PRIVILEGE>(x => x.USER_ID == userId).Select(x => x.PRIVILEGE_ID).ToListAsync();
        }

        public async Task<List<string>> GetRolePrivileges(int roleId)
        {
            return await _repository.Filter<ROLE_PRIVILEGE>(x => x.ROLE_ID == roleId).Select(x => x.PRIVILEGE_ID).ToListAsync();
        }

        public async Task SaveUserPrivileges(int userId, string[] privileges)
        {
            using (var ts = BeginTransaction())
            {
                var db = _repository.GetDbContext<TSCContext>();
                var userPrivileges = await db.USER_PRIVILEGES.Include(x => x.PRIVILEGE).Where(x => x.USER_ID == userId).ToListAsync();

                foreach (var removingPrivilges in userPrivileges.Where(x => !privileges.Contains(x.PRIVILEGE_ID)))
                {
                    db.Remove(removingPrivilges);
                }

                foreach (var newPrivilege in privileges.Where(x => !userPrivileges.Any(y => y.PRIVILEGE_ID == x)))
                {
                    db.Add(new USER_PRIVILEGE() { USER_ID = userId, PRIVILEGE_ID = newPrivilege });
                }

                await db.SaveChangesAsync();

                ts.Commit();
            }
        }

        public async Task SaveRolePrivileges(int roleId, string[] privileges)
        {
            using (var ts = BeginTransaction())
            {
                var db = _repository.GetDbContext<TSCContext>();
                var rolePrivileges = await db.ROLE_PRIVILEGES.Include(x => x.PRIVILEGE).Where(x => x.ROLE_ID == roleId).ToListAsync();

                foreach (var removingPrivilges in rolePrivileges.Where(x => !privileges.Contains(x.PRIVILEGE_ID)))
                {
                    db.Remove(removingPrivilges);
                }

                foreach (var newPrivilege in privileges.Where(x => !rolePrivileges.Any(y => y.PRIVILEGE_ID == x)))
                {
                    db.Add(new ROLE_PRIVILEGE() { ROLE_ID = roleId, PRIVILEGE_ID = newPrivilege });
                }

                await db.SaveChangesAsync();

                ts.Commit();
            }
        }

        public async Task SaveUserRoles(int userId, List<int> roles = null)
        {
            if (roles == null) roles = new List<int>();
            using (var ts = BeginTransaction())
            {
                var db = _repository.GetDbContext<TSCContext>();
                var userRoles = await db.USER_ROLES.Include(x => x.ROLE).Where(x => x.USER_ID == userId).ToListAsync();

                foreach (var removingRole in userRoles.Where(x => !roles.Contains(x.ROLE_ID)))
                {
                    db.Remove(removingRole);
                }

                foreach (var newRole in roles.Where(x => !userRoles.Any(y => y.ROLE_ID == x)))
                {
                    db.Add(new USER_ROLE() { USER_ID = userId, ROLE_ID = newRole });
                }

                await db.SaveChangesAsync();

                ts.Commit();
            }
        }
    }
}
