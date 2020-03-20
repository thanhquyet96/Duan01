using EPS.Utils.Repository.Audit;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Data.Entities
{
    [Table("USERS")]
    public partial class USER : IdentityUser<int>, IDeleteInfo<USER, int>, ICascadeDelete
    {
        public USER()
        {
            USER_PRIVILEGES = new HashSet<USER_PRIVILEGE>();
            USER_ROLES = new HashSet<USER_ROLE>();
        }

        [Column(TypeName = "VARCHAR2(250)")]
        public string FULL_NAME { get; set; }
        public bool IS_ADMINISTRATOR { get; set; }
        public bool? IS_EXPLOITING_USER { get; set; }
        public int UNIT_ID { get; set; }
        public int? SYNC_SOURCE { get; set; }

        //[ForeignKey("UNIT_ID")]
        //[InverseProperty("USERS")]
        //public virtual UNIT UNIT { get; set; }
        [InverseProperty("USER")]
        public virtual ICollection<USER_PRIVILEGE> USER_PRIVILEGES { get; set; }
        [InverseProperty("USER")]
        public virtual ICollection<USER_ROLE> USER_ROLES { get; set; }

        [Column("DELETED_DATE")]
        public DateTime? DeletedDate { get; set; }
        [Column("DELETED_USER_ID")]
        public int? DeletedUserId { get; set; }
        [ForeignKey("DeletedUserId")]
        public virtual USER DeletedUser { get; set; }

        public void OnDelete()
        {
            if (USER_PRIVILEGES.Count > 0)
            {
                throw new TSCException(TSCExceptionCode.DeleteRecordWithRelatedData, "quyền hạn");
            }
            if (USER_ROLES.Count > 0)
            {
                throw new TSCException(TSCExceptionCode.DeleteRecordWithRelatedData, "nhóm người dùng");
            }
        }
    }
}
