using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Data.Entities
{
    [Table("USER_PRIVILEGES")]
    public partial class USER_PRIVILEGE
    {
        [Key]
        public int USER_ID { get; set; }
        [Column(TypeName = "VARCHAR2(50)")]
        public string PRIVILEGE_ID { get; set; }

        [ForeignKey("PRIVILEGE_ID")]
        [InverseProperty("USER_PRIVILEGES")]
        public virtual PRIVILEGE PRIVILEGE { get; set; }
        [ForeignKey("USER_ID")]
        [InverseProperty("USER_PRIVILEGES")]
        public virtual USER USER { get; set; }
    }
}
