using System.ComponentModel.DataAnnotations;
using System;

namespace GASEC_RCA.Data
{
    public class Authentification
    {
        [Required]
        public Int64 UTIL_ID { get; set; }
        [Required]
        public string UTIL_NOM { get; set; }
        [Required]
        public string UTIL_PRENOM { get; set; }
        [Required]
        public string UTIL_NOM_COMPLET { get; set; }
		[Required]
		public string UTIL_LOGIN { get; set; }
		[Required]
        public string UTIL_PWD { get; set; }
        public string UTIL_EMAIL { get; set; }
        [Required]
        public int UTIL_STATUT { get; set; }
        [Required]
        public Int64 GEO_ID { get; set; }
        public string GEO_NOM { get; set; }
        [Required]
        public Int64 CODE_ZONE { get; set; }

        [Required]
        public Int64 RLE_ID { get; set; }
        [Required]
        public string RLE_NOM { get; set; }
    }
}
