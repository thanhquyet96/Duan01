using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Report.Entities
{
    [Table("RPT_11C_CK_TSC")]
    public partial class RPT_11C_CK_TSC : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        public int REPORT_YEAR { get; set; }
        public int ASSET_TYPE { get; set; }
        [Required]
        
        public string UNIT_CODE { get; set; }
        [Required]
        
        public string UNIT_NAME { get; set; }
        public int? RETRIEVED_QUANTITY { get; set; }
        
        public decimal? RETRIEVED_AREA { get; set; }
        
        public long? RETRIEVED_ORIGINAL_VALUE { get; set; }
        
        public long? RETRIEVED_RESIDUAL_VALUE { get; set; }
        public int? TRANSFERRED_QUANTITY { get; set; }
        
        public decimal? TRANSFERRED_AREA { get; set; }
        
        public long? TRANSFERRED_ORIGINAL_VALUE { get; set; }
        
        public long? TRANSFERRED_RESIDUAL_VALUE { get; set; }
        public int? SOLD_QUANTITY { get; set; }
        
        public decimal? SOLD_AREA { get; set; }
        
        public long? SOLD_ORIGINAL_VALUE { get; set; }
        
        public long? SOLD_RESIDUAL_VALUE { get; set; }
        public int? LIQUIDATION_QUANTITY { get; set; }
        
        public decimal? LIQUIDATION_AREA { get; set; }
        
        public long? LIQUIDATION_ORIGINAL_VALUE { get; set; }
        
        public long? LIQUIDATION_RESIDUAL_VALUE { get; set; }
        public int? DESTRUCTION_QUANTITY { get; set; }
        
        public decimal? DESTRUCTION_AREA { get; set; }
        
        public long? DESTRUCTION_ORIGINAL_VALUE { get; set; }
        
        public long? DESTRUCTION_RESIDUAL_VALUE { get; set; }
        
        public string NOTES { get; set; }
    }
}
