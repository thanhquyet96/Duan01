using EPS.Utils.Repository.Audit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Data.Entities
{
    [Table("ROLES")]
    public partial class ROLE : ICascadeDelete
    {
        public ROLE()
        {
            ROLE_PRIVILEGES = new HashSet<ROLE_PRIVILEGE>();
            USER_ROLES = new HashSet<USER_ROLE>();
        }
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR2(250)")]
        public string NAME { get; set; }
        public int? UNIT_ID { get; set; }
        [Column(TypeName = "VARCHAR2(4000)")]
        public string DESCRIPTION { get; set; }
        public bool? IS_EXPLOITING_ROLE { get; set; }

        //[ForeignKey("UNIT_ID")]
        //[InverseProperty("ROLES")]
        //public virtual UNIT UNIT { get; set; }
        [InverseProperty("ROLE")]
        public virtual ICollection<ROLE_PRIVILEGE> ROLE_PRIVILEGES { get; set; }
        [InverseProperty("ROLE")]
        public virtual ICollection<USER_ROLE> USER_ROLES { get; set; }

        public void OnDelete()
        {
            if (USER_ROLES.Count > 0)
            {
                throw new TSCException(TSCExceptionCode.DeleteRecordWithRelatedData, "nhóm người dùng");
            }

            ROLE_PRIVILEGES.Clear();
        }
    }
}
