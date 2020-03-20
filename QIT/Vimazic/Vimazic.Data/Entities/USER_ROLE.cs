using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Data.Entities
{
    [Table("USER_ROLES")]
    public partial class USER_ROLE
    {
        [Column(Order = 1)]
        [Key]
        public int USER_ID { get; set; }
        [Column(Order = 2)]
        [Key]
        public int ROLE_ID { get; set; }

        [ForeignKey("ROLE_ID")]
        [InverseProperty("USER_ROLES")]
        public virtual ROLE ROLE { get; set; }
        [ForeignKey("USER_ID")]
        [InverseProperty("USER_ROLES")]
        public virtual USER USER { get; set; }
    }
}
