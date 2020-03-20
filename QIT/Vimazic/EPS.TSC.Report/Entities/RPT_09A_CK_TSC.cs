using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Report.Entities
{
    [Table("RPT_09A_CK_TSC")]
    public partial class RPT_09A_CK_TSC : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        public int REPORT_YEAR { get; set; }
        public int ASSET_SOURCE { get; set; }
        public int ASSET_TYPE { get; set; }
        
        public string ASSET_CODE { get; set; }
        [Required]
        
        public string ASSET_NAME { get; set; }
        
        public string CALCULATION_UNIT { get; set; }
        
        public long? QUANTITY { get; set; }
        
        public string BRAND { get; set; }
        
        public string COUNTRY_OF_MANUFACTURER { get; set; }
        
        public string YEAR_OF_MANUFACTURER { get; set; }
        
        public long? PURCHASE_RENTAL_PRICE { get; set; }
        
        public string PURCHASE_RENTAL_FORM { get; set; }
        
        public string SUPPLIER { get; set; }
        
        public long? DISCOUNT_COMMISSION { get; set; }
        
        public long? DISCOUNT_COMMISSION_TO_BUDGET { get; set; }
        
        public long? DISCOUNT_COMMISSION_REMAIN { get; set; }
        
        public string NOTES { get; set; }
    }
}
