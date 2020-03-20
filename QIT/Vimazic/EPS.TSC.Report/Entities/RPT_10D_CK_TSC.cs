using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Report.Entities
{
    [Table("RPT_10D_CK_TSC")]
    public partial class RPT_10D_CK_TSC : MARK_DELETED
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
        
        public decimal? BUSINESS_QUANTITY { get; set; }
        
        public long? BUSINESS_ORRIGINAL_VALUE { get; set; }
        
        public long? BUSINESS_RESIDUAL_VALUE { get; set; }
        
        public long? BUSINESS_REVENUE_VALUE { get; set; }
        
        public decimal? LEASE_QUANTITY_AREA { get; set; }
        
        public long? LEASE_ORRIGINAL_VALUE { get; set; }
        
        public long? LEASE_RESIDUAL_VALUE { get; set; }
        
        public long? LEASE_REVENUE_VALUE { get; set; }
        
        public decimal? VENTURE_QUANTITY_AREA { get; set; }
        
        public long? VENTURE_ORRIGINAL_VALUE { get; set; }
        
        public long? VENTURE_RESIDUAL_VALUE { get; set; }
        
        public long? VENTURE_REVENUE_VALUE { get; set; }
    }
}
