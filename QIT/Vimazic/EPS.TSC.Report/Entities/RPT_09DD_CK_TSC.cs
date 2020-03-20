using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Report.Entities
{
    [Table("RPT_09DD_CK_TSC")]
    public partial class RPT_09DD_CK_TSC : MARK_DELETED
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
        
        public decimal? BUSINESS_QUANTITY_AREA { get; set; }
        
        public string BUSINESS_FORM { get; set; }
        
        public long? BUSINESS_VALUE { get; set; }
        
        public decimal? LEASE_QUANTITY_AREA { get; set; }
        
        public long? LEASE_PRICE { get; set; }
        
        public string LEASE_ORGANIZER { get; set; }
        
        public string LEASE_CONTRACT { get; set; }
        
        public string LEASE_PERIOD { get; set; }
        
        public long? LEASE_VALUE { get; set; }
        
        public decimal? VENTURE_QUANTITY_AREA { get; set; }
        
        public string VENTURE_FORM { get; set; }
        
        public string VENTURE_PARTNER { get; set; }
        
        public string VENTURE_CONTRACT { get; set; }
        
        public string VENTURE_PERIOD { get; set; }
        
        public long? VENTURE_VALUE { get; set; }
    }
}
