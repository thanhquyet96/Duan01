using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Report.Entities
{
    [Table("RPT_09B_CK_TSC")]
    public partial class RPT_09B_CK_TSC : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        public int REPORT_YEAR { get; set; }
        
        public string ASSET_CODE { get; set; }
        [Required]
        
        public string ASSET_NAME { get; set; }
        
        public decimal? LAND_AREA { get; set; }
        
        public long? LAND_VALUE { get; set; }
        
        public decimal? LAND_AREA_OFFICE_USAGE { get; set; }
        
        public decimal? LAND_AREA_NONE_BUSINESS_USAGE { get; set; }
        
        public decimal? LAND_AREA_BUSINESS_USAGE { get; set; }
        
        public decimal? LAND_AREA_LEASE_USAGE { get; set; }
        
        public decimal? LAND_AREA_VENTURE_USAGE { get; set; }
        
        public decimal? LAND_AREA_MIX_USAGE { get; set; }
        public int? YEAR_OF_USE { get; set; }
        
        public decimal? HOUSE_AREA { get; set; }
        
        public long? HOUSE_ORIGINAL_VALUE { get; set; }
        
        public long? HOUSE_RESIDUAL_VALUE { get; set; }
        
        public decimal? HOUSE_AREA_OFFICE_USAGE { get; set; }
        
        public decimal? HOUSE_AREA_NONE_BUSINESS_USAGE { get; set; }
        
        public decimal? HOUSE_AREA_BUSINESS_USAGE { get; set; }
        
        public decimal? HOUSE_AREA_LEASE_USAGE { get; set; }
        
        public decimal? HOUSE_AREA_VENTURE_USAGE { get; set; }
        
        public decimal? HOUSE_AREA_MIX_USAGE { get; set; }
        
        public string NOTES { get; set; }
    }
}
