using EPS.Utils.Repository.Audit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EPS.TSC.Data.Entities
{
    public class MARK_DELETED : IDeleteInfo<USER, int>
    {
        [Column("DELETED_DATE")]
        public DateTime? DeletedDate { get; set; }
        [Column("DELETED_USER_ID")]
        public int? DeletedUserId { get; set; }
        [ForeignKey("DeletedUserId")]
        public virtual USER DeletedUser { get; set; }
    }
}
