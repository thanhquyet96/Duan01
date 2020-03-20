using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Report.Entities
{
    [Table("RPT_BCTSCTKVHV")]
    public partial class RPT_BCTSCTKVHV : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        
        public DateTime REPORT_DATE { get; set; }
        
        public string ASSET_CODE { get; set; }
        [Required]
        
        public string ASSET_NAME { get; set; }
        public int? QUANTITY { get; set; }
        
        public decimal? AREA { get; set; }
        
        public decimal? AREA_EXPLOITED { get; set; }
        
        public decimal? AREA_UNUSED { get; set; }
    }
}
