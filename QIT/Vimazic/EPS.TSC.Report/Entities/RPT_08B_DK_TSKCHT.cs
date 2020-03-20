using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Report.Entities
{
    [Table("RPT_08B_DK_TSKCHT_01")]
    public partial class RPT_08B_DK_TSKCHT_01 : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        
        public DateTime REPORT_DATE { get; set; }
        public int INFRASTRUCTURE_ASSET_TYPE { get; set; }
        public int EXPLOITATION_TYPE { get; set; }
        
        public decimal? QUANTITY_VOLUME { get; set; }
        
        public decimal? LAND_AREA { get; set; }
        
        public decimal? FLOOR_AREA { get; set; }
        
        public long? ORIGINAL_VALUE { get; set; }
        
        public long? RESIDUAL_VALUE { get; set; }
        
        public string EXPLOITING_PERIOD { get; set; }
        
        public string EXPLOITING_ORGANIZATION { get; set; }
        
        public long? REVENUE_VALUE { get; set; }
        
        public long? EXPENSE_VALUE { get; set; }
        
        public long? INCOME_VALUE { get; set; }
        
        public long? BUDGET_VALUE { get; set; }
    }

    [Table("RPT_08B_DK_TSKCHT_02")]
    public partial class RPT_08B_DK_TSKCHT_02 : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        
        public DateTime REPORT_DATE { get; set; }
        public int INFRASTRUCTURE_ASSET_TYPE { get; set; }
        public int EXPLOITATION_TYPE { get; set; }
        public int UNIT_TYPE { get; set; }
        
        public decimal? QUANTITY_VOLUME { get; set; }
        
        public decimal? LAND_AREA { get; set; }
        
        public decimal? FLOOR_AREA { get; set; }
        
        public long? ORIGINAL_VALUE { get; set; }
        
        public long? RESIDUAL_VALUE { get; set; }
        
        public string EXPLOITING_PERIOD { get; set; }
        
        public string EXPLOITING_ORGANIZATION { get; set; }
        
        public long? REVENUE_VALUE { get; set; }
        
        public long? EXPENSE_VALUE { get; set; }
        
        public long? INCOME_VALUE { get; set; }
        
        public long? BUDGET_VALUE { get; set; }
    }

    [Table("RPT_08B_DK_TSKCHT_03")]
    public partial class RPT_08B_DK_TSKCHT_03 : MARK_DELETED
    {
        
        public long ID { get; set; }
        [Required]
        
        public string REPORTED_UNIT { get; set; }
        public int REPORTED_USER_ID { get; set; }
        
        public DateTime SYNC_DATE { get; set; }
        
        public DateTime REPORT_DATE { get; set; }
        public int INFRASTRUCTURE_ASSET_TYPE { get; set; }
        public int EXPLOITATION_TYPE { get; set; }
        
        public string UNIT_CODE { get; set; }
        
        public string UNIT_NAME { get; set; }
        
        public decimal? QUANTITY_VOLUME { get; set; }
        
        public decimal? LAND_AREA { get; set; }
        
        public decimal? FLOOR_AREA { get; set; }
        
        public long? ORIGINAL_VALUE { get; set; }
        
        public long? RESIDUAL_VALUE { get; set; }
        
        public string EXPLOITING_PERIOD { get; set; }
        
        public string EXPLOITING_ORGANIZATION { get; set; }
        
        public long? REVENUE_VALUE { get; set; }
        
        public long? EXPENSE_VALUE { get; set; }
        
        public long? INCOME_VALUE { get; set; }
        
        public long? BUDGET_VALUE { get; set; }
    }
}
