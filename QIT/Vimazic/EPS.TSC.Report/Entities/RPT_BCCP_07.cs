using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Report.Entities
{
    [Table("RPT_BCCP_07")]
    public partial class RPT_BCCP_07 : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        
        public DateTime REPORT_DATE { get; set; }
        public int VEHICLE_USAGE_PURPOSE { get; set; }
        public int? VEHICLE_TYPE { get; set; }
        public int ASSET_TYPE { get; set; }
        public int? QUANTITY { get; set; }
        
        public decimal? QUANTITY_PROPORTION { get; set; }
        
        public long? ORIGINAL_VALUE { get; set; }
        
        public decimal? ORIGINAL_VALUE_PROPORTION { get; set; }
        
        public long? RESIDUAL_VALUE { get; set; }
        
        public decimal? RESIDUAL_VALUE_PROPORTION { get; set; }
    }
}
