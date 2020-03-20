using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Data.Entities
{
    [Table("IDENTITY_CLIENTS")]
    public partial class IDENTITY_CLIENT
    {
        [Column(TypeName = "VARCHAR2(900)")]
        [Key]
        public string IDENTITY_CLIENT_ID { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR2(100)")]
        public string DESCRIPTION { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR2(4000)")]
        public string SECRET_KEY { get; set; }
        public int CLIENT_TYPE { get; set; }
        public bool IS_ACTIVE { get; set; }
        public int REFRESH_TOKEN_LIFE_TIME { get; set; }
        [Column(TypeName = "VARCHAR2(1000)")]
        public string ALLOWED_ORIGIN { get; set; }
    }
}
