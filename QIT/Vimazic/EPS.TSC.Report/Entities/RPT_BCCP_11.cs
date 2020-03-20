using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Report.Entities
{
    [Table("RPT_BCCP_11")]
    public partial class RPT_BCCP_11 : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        
        public DateTime REPORT_DATE { get; set; }
        public int ADMINISTRATIVE_LEVEL { get; set; }
        public int ASSET_TYPE { get; set; }
        [Required]
        
        public string UNIT_CODE { get; set; }
        [Required]
        
        public string UNIT_NAME { get; set; }
        public int? QUANTITY { get; set; }
        
        public decimal? AREA { get; set; }
        
        public long? ORIGINAL_VALUE { get; set; }
        
        public long? ORIGINAL_VALUE_BUDGET_SOURCE { get; set; }
        
        public long? ORIGINAL_VALUE_OTHER_SOURCE { get; set; }
        
        public long? RESIDUAL_VALUE { get; set; }
    }
}
