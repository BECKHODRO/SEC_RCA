using GASEC_RCA.Data;
using Npgsql;

namespace GASEC_RCA.Service
{
	public class ActesMariageService
	{
		Connexion connecter = new Connexion();
		string con;

		void connectionString()
		{
			connecter.chaineDeConnexion();
			con = connecter.lienCnx;
		}



		public void AddActesNaissance(ActesDeMariage actesMariage)
		{
			connectionString();
			using (NpgsqlConnection connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("CREER_REGION", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO T_PERSONNE VALUES(@PERS_ID_EPOUX, @PERS_NOM_EPOUX, @PERS_PRENOM_EPOUX" +
					", @PERS_NOM_COMPLET_EPOUX, @PERS_DATE_NAISS_EPOUX, @PERS_LIEU_NAISS_EPOUX)", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@PERS_ID_EPOUX", actesMariage.PERS_ID_EPOUX);
				cmd.Parameters.AddWithValue("@PERS_NOM_EPOUX", actesMariage.PERS_NOM_EPOUX);
				cmd.Parameters.AddWithValue("@PERS_PRENOM_EPOUX", actesMariage.PERS_PRENOM_EPOUX);
				cmd.Parameters.AddWithValue("@PERS_NOM_COMPLET_EPOUX", actesMariage.PERS_NOM_EPOUX + " " + actesMariage.PERS_PRENOM_EPOUX);
				cmd.Parameters.AddWithValue("@PERS_DATE_NAISS_EPOUX", actesMariage.PERS_DATE_NAISS_EPOUX);
				cmd.Parameters.AddWithValue("@PERS_LIEU_NAISS_EPOUX", actesMariage.PERS_LIEU_NAISS_EPOUX);
				connection.Open();
				cmd.ExecuteNonQuery();

				cmd.CommandText = "INSERT INTO T_PERSONNE VALUES(@PERS_ID_EPOUX, @PERS_NOM_EPOUX, @PERS_PRENOM_EPOUX" +
				", @PERS_NOM_COMPLET_EPOUX, @PERS_DATE_NAISS_EPOUX, @PERS_LIEU_NAISS_EPOUX)";
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@PERS_ID_EPOUSE", actesMariage.PERS_ID_EPOUSE);
				cmd.Parameters.AddWithValue("@PERS_NOM_EPOUSE", actesMariage.PERS_NOM_EPOUSE);
				cmd.Parameters.AddWithValue("@PERS_PRENOM_EPOUSE", actesMariage.PERS_PRENOM_EPOUSE);
				cmd.Parameters.AddWithValue("@PERS_NOM_COMPLET_EPOUSE", actesMariage.PERS_NOM_EPOUSE + " " + actesMariage.PERS_NOM_EPOUSE);
				cmd.Parameters.AddWithValue("@PERS_DATE_NAISS_EPOUSE", actesMariage.PERS_DATE_NAISS_EPOUSE);
				cmd.Parameters.AddWithValue("@PERS_LIEU_NAISS_EPOUSE", actesMariage.PERS_LIEU_NAISS_EPOUSE);
				cmd.ExecuteNonQuery();


				cmd.CommandText = "INSERT INTO T_ACTES_DE_MARIAGE VALUES(@ACT_NUM, @PERS_ID_EPOUX, @PERS_PRENOM_EPOUX" +
					", @PERS_NOM_COMPLET_EPOUX, @PERS_DATE_NAISS_EPOUX, @PERS_LIEU_NAISS_EPOUX, @ACT_NATIONALITE_EPOUX" +
					", @ACT_PROFESSION_EPOUX, @ACT_DOMICILE_EPOUX, @ACT_ID_NATIONALITE_EPOUX, @ACT_NOM_PERE_EPOUX" +
					", @ACT_PRENOM_PERE_EPOUX, @ACT_NOM_COMPLET_PERE_EPOUX, @ACT_NOM_MERE_EPOUX, @ACT_PRENOM_MERE_EPOUX" +
					", @ACT_NOM_COMPLET_MERE_EPOUX, @ACT_NOM_TEMOIN_EPOUX, @ACT_PRENOM_TEMOIN_EPOUX, @ACT_NOM_COMPLET_TEMOIN_EPOUX" +
					", @ACT_DATE_NAISS_TEMOIN_EPOUX, @ACT_LIEU_NAISS_TEMOIN_EPOUX, @ACT_DOMICILE_TEMOIN_EPOUX, @PERS_ID_EPOUSE" +
					", @PERS_NOM_EPOUSE, @PERS_PRENOM_EPOUSE, @PERS_NOM_COMPLET_EPOUSE, @PERS_DATE_NAISS_EPOUSE, @PERS_LIEU_NAISS_EPOUSE" +
					", @ACT_NATIONALITE_EPOUSE, @ACT_PROFESSION_EPOUSE, @ACT_DOMICILE_EPOUSE, @ACT_ID_NATIONALITE_EPOUSE" +
					", @ACT_NOM_PERE_EPOUSE, @ACT_PRENOM_PERE_EPOUSE, @ACT_NOM_COMPLET_PERE_EPOUSE, @ACT_NOM_MERE_EPOUSE" +
					", @ACT_PRENOM_MERE_EPOUSE, @ACT_NOM_COMPLET_MERE_EPOUSE, @ACT_NOM_TEMOIN_EPOUSE, @ACT_PRENOM_TEMOIN_EPOUSE" +
					", @ACT_NOM_COMPLET_TEMOIN_EPOUSE, @ACT_DATE_NAISS_TEMOIN_EPOUSE, @ACT_LIEU_NAISS_TEMOIN_EPOUSE, @ACT_DOMICILE_TEMOIN_EPOUSE" +
					", @ACT_REGIME_MATRIMONIAL, @ACT_OPTION_MATRIMONIALE, @ACT_DOT, @ACT_DATE_CELEBRATION, @ACT_HEURE_CELEBRATION, @CEC_ID)";
				cmd.CommandType = System.Data.CommandType.Text;
				
				cmd.Parameters.AddWithValue("@ACT_NUM", actesMariage.ACT_NUM);
				
				cmd.Parameters.AddWithValue("@PERS_ID_EPOUX", actesMariage.PERS_ID_EPOUX);
				cmd.Parameters.AddWithValue("@PERS_NOM_EPOUX", actesMariage.PERS_NOM_EPOUX);
				cmd.Parameters.AddWithValue("@PERS_PRENOM_EPOUX", actesMariage.PERS_PRENOM_EPOUX);
				cmd.Parameters.AddWithValue("@PERS_NOM_COMPLET_EPOUX", actesMariage.PERS_NOM_EPOUX + " " + actesMariage.PERS_PRENOM_EPOUX);
				cmd.Parameters.AddWithValue("@PERS_DATE_NAISS_EPOUX", actesMariage.PERS_DATE_NAISS_EPOUX);
				cmd.Parameters.AddWithValue("@PERS_LIEU_NAISS_EPOUX", actesMariage.PERS_LIEU_NAISS_EPOUX);
				cmd.Parameters.AddWithValue("@ACT_NATIONALITE_EPOUX", actesMariage.ACT_NATIONALITE_EPOUX);
				cmd.Parameters.AddWithValue("@ACT_PROFESSION_EPOUX", actesMariage.ACT_PROFESSION_EPOUX);
				cmd.Parameters.AddWithValue("@ACT_DOMICILE_EPOUX", actesMariage.ACT_DOMICILE_EPOUX);
				cmd.Parameters.AddWithValue("@ACT_ID_NATIONALITE_EPOUX", actesMariage.ACT_ID_NATIONALITE_EPOUX);
				
				cmd.Parameters.AddWithValue("@ACT_NOM_PERE_EPOUX", actesMariage.ACT_NOM_PERE_EPOUX);
				cmd.Parameters.AddWithValue("@ACT_PRENOM_PERE_EPOUX", actesMariage.ACT_PRENOM_PERE_EPOUX);
				cmd.Parameters.AddWithValue("@ACT_NOM_COMPLET_PERE_EPOUX", actesMariage.ACT_NOM_PERE_EPOUX + " " + actesMariage.ACT_PRENOM_PERE_EPOUX);
				
				cmd.Parameters.AddWithValue("@ACT_NOM_MERE_EPOUX", actesMariage.ACT_NOM_MERE_EPOUX);
				cmd.Parameters.AddWithValue("@ACT_PRENOM_MERE_EPOUX", actesMariage.ACT_PRENOM_MERE_EPOUX);
				cmd.Parameters.AddWithValue("@ACT_NOM_COMPLET_MERE", actesMariage.ACT_NOM_MERE_EPOUX + " " + actesMariage.ACT_PRENOM_MERE_EPOUX);

				cmd.Parameters.AddWithValue("@ACT_NOM_TEMOIN_EPOUX", actesMariage.ACT_NOM_TEMOIN_EPOUX);
				cmd.Parameters.AddWithValue("@ACT_PRENOM_TEMOIN_EPOUX", actesMariage.ACT_PRENOM_TEMOIN_EPOUX);
				cmd.Parameters.AddWithValue("@ACT_NOM_COMPLET_TEMOIN_EPOUX", actesMariage.ACT_NOM_TEMOIN_EPOUX + " " + actesMariage.ACT_PRENOM_TEMOIN_EPOUX);
				cmd.Parameters.AddWithValue("@ACT_DATE_NAISS_TEMOIN_EPOUX", actesMariage.ACT_DATE_NAISS_TEMOIN_EPOUX);
				cmd.Parameters.AddWithValue("@ACT_LIEU_NAISS_TEMOIN_EPOUX", actesMariage.ACT_LIEU_NAISS_TEMOIN_EPOUX);
				cmd.Parameters.AddWithValue("@ACT_DOMICILE_TEMOIN_EPOUX", actesMariage.ACT_DOMICILE_TEMOIN_EPOUX);

				cmd.Parameters.AddWithValue("@PERS_ID_EPOUSE", actesMariage.PERS_ID_EPOUSE);
				cmd.Parameters.AddWithValue("@PERS_NOM_EPOUSE", actesMariage.PERS_NOM_EPOUSE);
				cmd.Parameters.AddWithValue("@PERS_PRENOM_EPOUSE", actesMariage.PERS_PRENOM_EPOUSE);
				cmd.Parameters.AddWithValue("@PERS_NOM_COMPLET_EPOUSE", actesMariage.PERS_NOM_EPOUSE + " " + actesMariage.PERS_PRENOM_EPOUSE);
				cmd.Parameters.AddWithValue("@PERS_DATE_NAISS_EPOUSE", actesMariage.PERS_DATE_NAISS_EPOUSE);
				cmd.Parameters.AddWithValue("@PERS_LIEU_NAISS_EPOUSE", actesMariage.PERS_LIEU_NAISS_EPOUSE);
				cmd.Parameters.AddWithValue("@ACT_NATIONALITE_EPOUSE", actesMariage.ACT_NATIONALITE_EPOUSE);
				cmd.Parameters.AddWithValue("@ACT_PROFESSION_EPOUSE", actesMariage.ACT_PROFESSION_EPOUSE);
				cmd.Parameters.AddWithValue("@ACT_DOMICILE_EPOUSE", actesMariage.ACT_DOMICILE_EPOUSE);
				cmd.Parameters.AddWithValue("@ACT_ID_NATIONALITE_EPOUSE", actesMariage.ACT_ID_NATIONALITE_EPOUSE);
				
				cmd.Parameters.AddWithValue("@ACT_NOM_PERE_EPOUSE", actesMariage.ACT_NOM_PERE_EPOUSE);
				cmd.Parameters.AddWithValue("@ACT_PRENOM_PERE_EPOUSE", actesMariage.ACT_PRENOM_PERE_EPOUSE);
				cmd.Parameters.AddWithValue("@ACT_NOM_COMPLET_PERE_EPOUSE", actesMariage.ACT_NOM_PERE_EPOUSE + " " + actesMariage.ACT_PRENOM_PERE_EPOUSE);

				cmd.Parameters.AddWithValue("@ACT_NOM_MERE_EPOUSE", actesMariage.ACT_NOM_MERE_EPOUSE);
				cmd.Parameters.AddWithValue("@ACT_PRENOM_MERE_EPOUSE", actesMariage.ACT_PRENOM_MERE_EPOUSE);
				cmd.Parameters.AddWithValue("@ACT_NOM_COMPLET_MERE_EPOUSE", actesMariage.ACT_NOM_MERE_EPOUSE + " " + actesMariage.ACT_PRENOM_MERE_EPOUSE);
				
				cmd.Parameters.AddWithValue("@ACT_NOM_TEMOIN_EPOUSE", actesMariage.ACT_NOM_TEMOIN_EPOUSE);
				cmd.Parameters.AddWithValue("@ACT_PRENOM_TEMOIN_EPOUSE", actesMariage.ACT_PRENOM_TEMOIN_EPOUSE);
				cmd.Parameters.AddWithValue("@ACT_NOM_COMPLET_TEMOIN_EPOUSE", actesMariage.ACT_NOM_TEMOIN_EPOUSE + " " + actesMariage.ACT_PRENOM_TEMOIN_EPOUSE);
				cmd.Parameters.AddWithValue("@ACT_DATE_NAISS_TEMOIN_EPOUSE", actesMariage.ACT_DATE_NAISS_TEMOIN_EPOUSE);
				cmd.Parameters.AddWithValue("@ACT_LIEU_NAISS_TEMOIN_EPOUSE", actesMariage.ACT_LIEU_NAISS_TEMOIN_EPOUSE);
				cmd.Parameters.AddWithValue("@ACT_DOMICILE_TEMOIN_EPOUSE", actesMariage.ACT_DOMICILE_TEMOIN_EPOUSE);
				
				cmd.Parameters.AddWithValue("@ACT_REGIME_MATRIMONIAL", actesMariage.ACT_REGIME_MATRIMONIAL);
				cmd.Parameters.AddWithValue("@ACT_OPTION_MATRIMONIALE", actesMariage.ACT_OPTION_MATRIMONIALE);
				
				cmd.Parameters.AddWithValue("@ACT_DATE_CELEBRATION", actesMariage.ACT_DATE_CELEBRATION);
				cmd.Parameters.AddWithValue("@ACT_HEURE_CELEBRATION", actesMariage.ACT_HEURE_CELEBRATION);

				cmd.Parameters.AddWithValue("@CEC_ID", actesMariage.CEC_ID);
				

				//cmd.Parameters.AddWithValue("@ARRDT_ID", actesNaissance.ARRDT_ID);

				//connection.Open();
				cmd.ExecuteNonQuery();
				connection.Close();

			}
		}


	}
}
