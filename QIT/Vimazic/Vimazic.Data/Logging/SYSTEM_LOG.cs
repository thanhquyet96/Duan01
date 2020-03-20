using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Data.Logging
{
    [Table("SYSTEM_LOGS")]
    public partial class SYSTEM_LOG
    {
        public long ID { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime DATE { get; set; }
        [Column(TypeName = "CLOB")]
        public string ORIGIN { get; set; }
        [Column(TypeName = "VARCHAR2(50)")]
        public string LOG_LEVEL { get; set; }
        [Column(TypeName = "VARCHAR2(4000)")]
        public string MESSAGE { get; set; }
        [Column(TypeName = "CLOB")]
        public string EXCEPTION { get; set; }
        [Column(TypeName = "VARCHAR2(250)")]
        public string ACTOR { get; set; }
        [Column(TypeName = "VARCHAR2(250)")]
        public string ACTION { get; set; }
        [Column(TypeName = "CLOB")]
        public string DATA { get; set; }
    }
}
