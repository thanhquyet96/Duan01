using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Report.Entities
{
    [Table("RPT_10A_CK_TSC")]
    public partial class RPT_10A_CK_TSC : MARK_DELETED
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
        public int? INVESTMENT_QUANTITY { get; set; }
        
        public decimal? INVESTMENT_AREA { get; set; }
        
        public long? INVESTMENT_VALUE { get; set; }
        public int? RECEPTION_QUANTITY { get; set; }
        
        public decimal? RECEPTION_AREA { get; set; }
        
        public long? RECEPTION_VALUE { get; set; }
        public int? LEASE_QUANTITY { get; set; }
        
        public decimal? LEASE_AREA { get; set; }
        
        public long? LEASE_VALUE { get; set; }
    }
}
