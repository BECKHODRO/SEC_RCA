using System;

namespace GASEC_RCA.Data
{
    public class ActesDeNaissance
    {
        public Int64 PERS_ID { get; set; }
        public string PERS_NOM { get; set; }
        public string PERS_PRENOM { get; set; }
        public string PERS_NOM_COMPLET { get; set; }
        public string PERS_DATE_NAISS { get; set; }
        public string PERS_LIEU_NAISS { get; set; }

        public Int64 ACT_NUM { get; set; }
        public string ACT_DATE_NAISS { get; set; }
        public string ACT_HEURE_NAISS { get; set; }
        public string ACT_LIEU_NAISS { get; set; }
        public string ACT_SEXE { get; set; }
        public string ACT_NOM_PERE { get; set; }
        public string ACT_PRENOM_PERE { get; set; }
        public string ACT_NOM_COMPLET_PERE { get; set; }

		public string ACT_DATE_NAISS_PERE { get; set; }
		public string ACT_LIEU_NAISS_PERE { get; set; }
		public string ACT_NATIONALITE_PERE { get; set; }
		public string ACT_PROFESSION_PERE { get; set; }
		public string ACT_DOMICILE_PERE { get; set; }


		public string ACT_NOM_MERE { get; set; }
        public string ACT_PRENOM_MERE { get; set; }
        public string ACT_NOM_COMPLET_MERE { get; set; }


		public string ACT_DATE_NAISS_MERE { get; set; }
		public string ACT_LIEU_NAISS_MERE { get; set; }
		public string ACT_NATIONALITE_MERE { get; set; }
		public string ACT_PROFESSION_MERE { get; set; }
		public string ACT_DOMICILE_MERE { get; set; }


		public string ACT_OFFICIER_ETAT_CIVIL { get; set; }
        public Int64 ACT_ID_NATIONALITE_PERE { get; set; }
        public Int64 ACT_ID_NATIONALITE_MERE { get; set; }

        public Int64 CEC_ID { get; set; }

    }
}
