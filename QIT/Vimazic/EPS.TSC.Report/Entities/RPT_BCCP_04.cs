using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Report.Entities
{
    [Table("RPT_BCCP_04")]
    public partial class RPT_BCCP_04 : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        
        public DateTime REPORT_DATE { get; set; }
        public int? ORGANIZATION_ASSET_TYPE { get; set; }
        public int? INFRASTRUCTURE_ASSET_TYPE { get; set; }
        public int? NATIONAL_PUBLIC_ASSET_TYPE { get; set; }
        public int? QUANTITY { get; set; }
        
        public decimal? AREA { get; set; }
        
        public long? ORIGINAL_VALUE { get; set; }
        
        public long? RESIDUAL_VALUE { get; set; }
        
        public decimal? ORIGINAL_VALUE_PROPORTION { get; set; }
    }
}
