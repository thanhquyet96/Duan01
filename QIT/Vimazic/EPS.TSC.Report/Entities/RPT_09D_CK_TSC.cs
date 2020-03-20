using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Report.Entities
{
    [Table("RPT_09D_CK_TSC")]
    public partial class RPT_09D_CK_TSC : MARK_DELETED
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
        
        public long? ORIGINAL_VALUE_BUDGET_SOURCE { get; set; }
        
        public long? ORIGINAL_VALUE_OTHER_SOURCE { get; set; }
        public int? HANDLING_TRANSFERRED { get; set; }
        public int? HANDLING_SOLD { get; set; }
        public int? HANDLING_LIQUIDATION { get; set; }
        public int? HANDLING_DESTRUCTION { get; set; }
        public int? HANDLING_LOST_RUINED { get; set; }
        public int? HANDLING_OTHER { get; set; }
        
        public string HANDLING_RESULT { get; set; }
        
        public long? HANDLING_VALUE { get; set; }
        
        public long? HANDLING_VALUE_IN_CUSTODY { get; set; }
        
        public long? HANDLING_VALUE_NOT_IN_CUSTODY { get; set; }
        
        public long? HANDLING_COST { get; set; }
        
        public string NOTES { get; set; }
    }
}
