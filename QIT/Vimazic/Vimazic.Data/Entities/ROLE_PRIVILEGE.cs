using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Data.Entities
{
    [Table("ROLE_PRIVILEGES")]
    public partial class ROLE_PRIVILEGE
    {
        [Key]
        public int ROLE_ID { get; set; }
        [Column(TypeName = "VARCHAR2(50)")]
        public string PRIVILEGE_ID { get; set; }

        [ForeignKey("PRIVILEGE_ID")]
        [InverseProperty("ROLE_PRIVILEGES")]
        public virtual PRIVILEGE PRIVILEGE { get; set; }
        [ForeignKey("ROLE_ID")]
        [InverseProperty("ROLE_PRIVILEGES")]
        public virtual ROLE ROLE { get; set; }
    }
}
