using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Data.Entities
{
    [Table("IDENTITY_REFRESH_TOKENS")]
    public partial class IDENTITY_REFRESH_TOKEN
    {
        [Key]
        [Column(Order = 1)]

        public string IDENTITY_REFRESH_TOKEN_ID { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR2(50)")]
        public string IDENTITY { get; set; }
        [Required]
        [Key]
        [Column(Order = 2)]

        public string CLIENT_ID { get; set; }
        public DateTime ISSUED_UTC { get; set; }
        public DateTime EXPIRES_UTC { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR2(4000)")]
        public string REFRESH_TOKEN { get; set; }

        public bool IS_EXPIRED { get { return DateTime.UtcNow >= EXPIRES_UTC; } }
    }
}
