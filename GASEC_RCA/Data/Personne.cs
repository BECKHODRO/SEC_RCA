using System;

namespace GASEC_RCA.Data
{
    public class Personne
    {
        public Int64 PERS_ID { get; set; }
        public string PERS_NOM { get; set; }
        public string PERS_PRENOM { get; set; }
        public string PERS_NOM_COMPLET { get; set; }
        public DateTime PERS_DATE_NAISS { get; set; }
        public string PERS_LIEU_NAISS { get; set; }
    }
}
