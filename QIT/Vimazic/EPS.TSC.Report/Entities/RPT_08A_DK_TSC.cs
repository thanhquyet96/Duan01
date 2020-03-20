using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Report.Entities
{
    [Table("RPT_08A_DK_TSC_01")]
    public partial class RPT_08A_DK_TSC_01 : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        
        public DateTime REPORT_DATE { get; set; }
        public int ASSET_TYPE { get; set; }
        public int? QUANTITY { get; set; }
        
        public decimal? AREA { get; set; }
        
        public decimal? STATE_MANAGEMENT_USAGE { get; set; }
        
        public decimal? NONE_BUSINESS_USAGE { get; set; }
        
        public decimal? BUSINESS_USAGE { get; set; }
        
        public decimal? LEASE_USAGE { get; set; }
        
        public decimal? VENTURE_USAGE { get; set; }
        
        public decimal? MIX_USAGE { get; set; }
    }

    [Table("RPT_08A_DK_TSC_02")]
    public partial class RPT_08A_DK_TSC_02 : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        
        public DateTime REPORT_DATE { get; set; }
        public int ASSET_TYPE { get; set; }
        public int UNIT_TYPE { get; set; }
        public int? QUANTITY { get; set; }
        
        public decimal? AREA { get; set; }
        
        public decimal? STATE_MANAGEMENT_USAGE { get; set; }
        
        public decimal? NONE_BUSINESS_USAGE { get; set; }
        
        public decimal? BUSINESS_USAGE { get; set; }
        
        public decimal? LEASE_USAGE { get; set; }
        
        public decimal? VENTURE_USAGE { get; set; }
        
        public decimal? MIX_USAGE { get; set; }
    }

    [Table("RPT_08A_DK_TSC_03")]
    public partial class RPT_08A_DK_TSC_03 : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        
        public DateTime REPORT_DATE { get; set; }
        public int ASSET_TYPE { get; set; }
        
        public string UNIT_CODE { get; set; }
        
        public string UNIT_NAME { get; set; }
        public int? QUANTITY { get; set; }
        
        public decimal? AREA { get; set; }
        
        public decimal? STATE_MANAGEMENT_USAGE { get; set; }
        
        public decimal? NONE_BUSINESS_USAGE { get; set; }
        
        public decimal? BUSINESS_USAGE { get; set; }
        
        public decimal? LEASE_USAGE { get; set; }
        
        public decimal? VENTURE_USAGE { get; set; }
        
        public decimal? MIX_USAGE { get; set; }
    }
}
