using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Report.Entities
{
    [Table("RPT_09C_CK_TSC")]
    public partial class RPT_09C_CK_TSC : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        public int REPORT_YEAR { get; set; }
        public int ASSET_TYPE { get; set; }
        
        public string ASSET_CODE { get; set; }
        [Required]
        
        public string ASSET_NAME { get; set; }
        [Required]
        
        public string UNIT_DEPARTMENT { get; set; }
        public int? QUANTITY { get; set; }
        
        public long? ORIGINAL_VALUE { get; set; }
        
        public long? ORIGINAL_VALUE_BUDGET_SOURCE { get; set; }
        
        public long? ORIGINAL_VALUE_OTHER_SOURCE { get; set; }
        
        public long? RESIDUAL_VALUE { get; set; }
        public int? INDIVIDUAL_USAGE { get; set; }
        public int? COMMON_USAGE { get; set; }
        public int? SPECIAL_USAGE { get; set; }
        public int? BUSINESS_USAGE { get; set; }
        public int? LEASE_USAGE { get; set; }
        public int? VENTURE_USAGE { get; set; }
        
        public string OTHER_USAGE { get; set; }
    }
}
