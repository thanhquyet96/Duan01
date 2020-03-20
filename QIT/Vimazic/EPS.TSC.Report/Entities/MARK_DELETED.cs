using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EPS.TSC.Report.Entities
{
    public class MARK_DELETED
    {
        [Column("DELETED_DATE")]
        public DateTime? DeletedDate { get; set; }
        [Column("DELETED_USER_ID")]
        public int? DeletedUserId { get; set; }
    }
}
