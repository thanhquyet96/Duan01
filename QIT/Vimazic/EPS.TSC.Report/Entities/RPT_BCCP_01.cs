using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Report.Entities
{
    [Table("RPT_BCCP_01")]
    public partial class RPT_BCCP_01 : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        
        public DateTime REPORT_DATE { get; set; }
        public int ADMINISTRATIVE_LEVEL { get; set; }
        public int? ORGANIZATION_ASSET_TYPE { get; set; }
        public int? INFRASTRUCTURE_ASSET_TYPE { get; set; }
        public int? NATIONAL_PUBLIC_ASSET_TYPE { get; set; }
        public int? QUANTITY { get; set; }
        
        public decimal? AREA { get; set; }
        
        public decimal? AREA_PROPORTION { get; set; }
        
        public long? VALUE { get; set; }
        
        public decimal? VALUE_PROPORTION { get; set; }
    }
}
