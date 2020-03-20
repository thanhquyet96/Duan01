using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Report.Entities
{
    [Table("RPT_08B_DK_TSC_01")]
    public partial class RPT_08B_DK_TSC_01 : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        
        public DateTime REPORT_START_DATE { get; set; }
        
        public DateTime REPORT_END_DATE { get; set; }
        public int ASSET_TYPE { get; set; }
        public int? OPENING_QUANTITY { get; set; }
        
        public decimal? OPENING_AREA { get; set; }
        
        public long? OPENING_VALUE { get; set; }
        public int? INCREMENT_QUANTITY { get; set; }
        
        public decimal? INCREMENT_AREA { get; set; }
        
        public long? INCREMENT_VALUE { get; set; }
        public int? DECREMENT_QUANTITY { get; set; }
        
        public decimal? DECREMENT_AREA { get; set; }
        
        public long? DECREMENT_VALUE { get; set; }
        public int? CLOSING_QUANTITY { get; set; }
        
        public decimal? CLOSING_AREA { get; set; }
        
        public long? CLOSING_VALUE { get; set; }
    }

    [Table("RPT_08B_DK_TSC_02")]
    public partial class RPT_08B_DK_TSC_02 : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        
        public DateTime REPORT_START_DATE { get; set; }
        
        public DateTime REPORT_END_DATE { get; set; }
        public int ASSET_TYPE { get; set; }
        public int UNIT_TYPE { get; set; }
        public int? OPENING_QUANTITY { get; set; }
        
        public decimal? OPENING_AREA { get; set; }
        
        public long? OPENING_VALUE { get; set; }
        public int? INCREMENT_QUANTITY { get; set; }
        
        public decimal? INCREMENT_AREA { get; set; }
        
        public long? INCREMENT_VALUE { get; set; }
        public int? DECREMENT_QUANTITY { get; set; }
        
        public decimal? DECREMENT_AREA { get; set; }
        
        public long? DECREMENT_VALUE { get; set; }
        public int? CLOSING_QUANTITY { get; set; }
        
        public decimal? CLOSING_AREA { get; set; }
        
        public long? CLOSING_VALUE { get; set; }
    }

    [Table("RPT_08B_DK_TSC_03")]
    public partial class RPT_08B_DK_TSC_03 : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        
        public DateTime REPORT_START_DATE { get; set; }
        
        public DateTime REPORT_END_DATE { get; set; }
        public int ASSET_TYPE { get; set; }
        
        public string UNIT_CODE { get; set; }
        
        public string UNIT_NAME { get; set; }
        public int? OPENING_QUANTITY { get; set; }
        
        public decimal? OPENING_AREA { get; set; }
        
        public long? OPENING_VALUE { get; set; }
        public int? INCREMENT_QUANTITY { get; set; }
        
        public decimal? INCREMENT_AREA { get; set; }
        
        public long? INCREMENT_VALUE { get; set; }
        public int? DECREMENT_QUANTITY { get; set; }
        
        public decimal? DECREMENT_AREA { get; set; }
        
        public long? DECREMENT_VALUE { get; set; }
        public int? CLOSING_QUANTITY { get; set; }
        
        public decimal? CLOSING_AREA { get; set; }
        
        public long? CLOSING_VALUE { get; set; }
    }
}
