using System;

namespace GASEC_RCA.Data
{
	public class ActesDeMariage
	{
		//EPOUX

		public Int64 PERS_ID_EPOUX { get; set; }
		public string PERS_NOM_EPOUX { get; set; }
		public string PERS_PRENOM_EPOUX { get; set; }
		public string PERS_NOM_COMPLET_EPOUX { get; set; }
		public string PERS_DATE_NAISS_EPOUX { get; set; }
		public string PERS_LIEU_NAISS_EPOUX { get; set; }
		public string ACT_NATIONALITE_EPOUX { get; set; }
		public string ACT_PROFESSION_EPOUX { get; set; }
		public string ACT_DOMICILE_EPOUX { get; set; }
		public Int64 ACT_ID_NATIONALITE_EPOUX { get; set; }
		public string ACT_NOM_PERE_EPOUX { get; set; }
		public string ACT_PRENOM_PERE_EPOUX { get; set; }
		public string ACT_NOM_COMPLET_PERE_EPOUX { get; set; }
		public string ACT_NOM_MERE_EPOUX { get; set; }
		public string ACT_PRENOM_MERE_EPOUX { get; set; }
		public string ACT_NOM_COMPLET_MERE_EPOUX { get; set; }

		public string ACT_NOM_TEMOIN_EPOUX { get; set; }
		public string ACT_PRENOM_TEMOIN_EPOUX { get; set; }
		public string ACT_NOM_COMPLET_TEMOIN_EPOUX { get; set; }
		public string ACT_DATE_NAISS_TEMOIN_EPOUX { get; set; }
		public string ACT_LIEU_NAISS_TEMOIN_EPOUX { get; set; }
		public string ACT_DOMICILE_TEMOIN_EPOUX { get; set; }


		//EPOUSE

		public Int64 PERS_ID_EPOUSE { get; set; }
		public string PERS_NOM_EPOUSE { get; set; }
		public string PERS_PRENOM_EPOUSE { get; set; }
		public string PERS_NOM_COMPLET_EPOUSE { get; set; }
		public string PERS_DATE_NAISS_EPOUSE { get; set; }
		public string PERS_LIEU_NAISS_EPOUSE { get; set; }
		public string ACT_NATIONALITE_EPOUSE { get; set; }
		public string ACT_PROFESSION_EPOUSE { get; set; }
		public string ACT_DOMICILE_EPOUSE { get; set; }
		public Int64 ACT_ID_NATIONALITE_EPOUSE { get; set; }
		public string ACT_NOM_PERE_EPOUSE { get; set; }
		public string ACT_PRENOM_PERE_EPOUSE { get; set; }
		public string ACT_NOM_COMPLET_PERE_EPOUSE { get; set; }
		public string ACT_NOM_MERE_EPOUSE { get; set; }
		public string ACT_PRENOM_MERE_EPOUSE { get; set; }
		public string ACT_NOM_COMPLET_MERE_EPOUSE { get; set; }

		public string ACT_NOM_TEMOIN_EPOUSE { get; set; }
		public string ACT_PRENOM_TEMOIN_EPOUSE { get; set; }
		public string ACT_NOM_COMPLET_TEMOIN_EPOUSE { get; set; }
		public string ACT_DATE_NAISS_TEMOIN_EPOUSE { get; set; }
		public string ACT_LIEU_NAISS_TEMOIN_EPOUSE { get; set; }
		public string ACT_DOMICILE_TEMOIN_EPOUSE { get; set; }

		//AUTRES

		public string ACT_REGIME_MATRIMONIAL { get; set; }
		public string ACT_OPTION_MATRIMONIALE { get; set; }
		public string ACT_DOT { get; set; }
		public string ACT_DATE_CELEBRATION { get; set; }
		public string ACT_HEURE_CELEBRATION { get; set; }

		public Int64 ACT_NUM { get; set; }
		public Int64 CEC_ID { get; set; }


	}
}
