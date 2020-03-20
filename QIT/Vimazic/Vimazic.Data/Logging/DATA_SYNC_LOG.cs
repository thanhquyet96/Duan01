using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Data.Logging
{
    [Table("DATA_SYNC_LOGS")]
    public partial class DATA_SYNC_LOG
    {
        public long ID { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime DATE { get; set; }
        [Column(TypeName = "CLOB")]
        public string ORIGIN { get; set; }
        public int SYCN_USER { get; set; }
        public bool DATA_TYPE { get; set; }
        public bool SYNC_TYPE { get; set; }
        public bool STATUS { get; set; }
        [Column(TypeName = "NUMBER(10,2)")]
        public decimal ELAPSED_TIME { get; set; }
        [Column(TypeName = "CLOB")]
        public string DATA { get; set; }
    }
}
