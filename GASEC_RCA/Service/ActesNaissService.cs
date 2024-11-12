using GASEC_RCA.Data;
using Npgsql;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace GASEC_RCA.Service
{
    public class ActesNaissService
    {
        Connexion connecter = new Connexion();
        string con;

        void connectionString()
        {
            connecter.chaineDeConnexion();
            con = connecter.lienCnx;
        }

        public IEnumerable<ActesDeNaissance> GetAllActesNaissance()
        {
            List<ActesDeNaissance> ActesDeNaissanceList = new List<ActesDeNaissance>();

            connectionString();
            using (var connection = new NpgsqlConnection(con))
            {
                //NpgsqlCommand cmd = new NpgsqlCommand("LISTE_REGION", connection);
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_PERSONNE P, T_ACTES_DE_NAISSANCE AN, T_CENTRE_ETAT_CIVIL CEC" +
					", T_ARRONDISSEMENT A, T_COMMUNE C, T_SOUS_PREFECTURE SP, T_PREFECTURE PRF, T_REGION R WHERE P.PERS_ID = AN.PERS_ID" +
					" AND AN.CEC_ID = CEC.CEC_ID AND CEC.ARRDT_ID = A.ARRDT_ID AND A.CMN_ID = C.CMN_ID AND C.SP_ID = SP.SP_ID AND SP.PRF_ID = PRF.PRF_ID AND " +
					" PRF.REG_ID = R.REG_ID ORDER BY P.PERS_ID ASC;", connection);
                cmd.CommandType = System.Data.CommandType.Text;
                connection.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ActesDeNaissance actesNaissance = new ActesDeNaissance();
                    actesNaissance.PERS_ID = Convert.ToInt64(rdr["PERS_ID"]);
                    actesNaissance.PERS_NOM = rdr["PERS_NOM"].ToString();
                    actesNaissance.PERS_PRENOM = rdr["PERS_PRENOM"].ToString();
                    actesNaissance.PERS_NOM_COMPLET = rdr["PERS_NOM_COMPLET"].ToString();
                    actesNaissance.PERS_DATE_NAISS = rdr["PERS_DATE_NAISS"].ToString();
					actesNaissance.PERS_LIEU_NAISS = rdr["PERS_LIEU_NAISS"].ToString();
                    actesNaissance.ACT_NUM = Convert.ToInt64(rdr["ACT_NUM"]);
                    actesNaissance.ACT_DATE_NAISS = rdr["ACT_DATE_NAISS"].ToString();
					actesNaissance.ACT_HEURE_NAISS = Convert.ToString(rdr["ACT_HEURE_NAISS"]);
                    actesNaissance.ACT_LIEU_NAISS = rdr["ACT_LIEU_NAISS"].ToString();
                    actesNaissance.ACT_SEXE = rdr["ACT_SEXE"].ToString();
                    actesNaissance.ACT_NOM_PERE = rdr["ACT_NOM_PERE"].ToString();
                    actesNaissance.ACT_PRENOM_PERE = rdr["ACT_PRENOM_PERE"].ToString();
                    actesNaissance.ACT_NOM_COMPLET_PERE = rdr["ACT_NOM_COMPLET_PERE"].ToString();
                    actesNaissance.ACT_NOM_MERE = rdr["ACT_NOM_MERE"].ToString();
                    actesNaissance.ACT_PRENOM_MERE = rdr["ACT_PRENOM_MERE"].ToString();
                    actesNaissance.ACT_NOM_COMPLET_MERE = rdr["ACT_NOM_COMPLET_MERE"].ToString();
                    actesNaissance.ACT_OFFICIER_ETAT_CIVIL = rdr["ACT_OFFICIER_ETAT_CIVIL"].ToString();
                    actesNaissance.ACT_ID_NATIONALITE_PERE = Convert.ToInt64(rdr["ACT_ID_NATIONALITE_PERE"].ToString());
                    actesNaissance.ACT_ID_NATIONALITE_MERE = Convert.ToInt64(rdr["ACT_ID_NATIONALITE_MERE"].ToString());


                    ActesDeNaissanceList.Add(actesNaissance);
                }
                connection.Close();
                //Console.WriteLine("Connection to PostgreSQL database established successfully.");
                // Votre code pour interagir avec la base de données
            }
            return ActesDeNaissanceList;
        }

        public DataTable dtListeActeNaissance = new DataTable();

		public NpgsqlDataReader rdr;

        public ActesDeNaissance GetActesDeNaissanceByID(int? id)
		{
			ActesDeNaissance actesDeNaissanceList = new ActesDeNaissance();

			connectionString();
			using (var connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_PERSONNE P, T_ACTES_DE_NAISSANCE A" +
				//	" WHERE P.PERS_ID = @PERS_ID AND P.PERS_ID = A.PERS_ID ORDER BY P.PERS_ID ASC;", connection);

				NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_PERSONNE P, T_ACTES_DE_NAISSANCE AN, T_CENTRE_ETAT_CIVIL CEC" +
					", T_ARRONDISSEMENT A, T_COMMUNE C, T_SOUS_PREFECTURE SP, T_PREFECTURE PRF, T_REGION R WHERE P.PERS_ID = @PERS_ID AND P.PERS_ID = AN.PERS_ID" +
					" AND AN.CEC_ID = CEC.CEC_ID AND CEC.ARRDT_ID = A.ARRDT_ID AND A.CMN_ID = C.CMN_ID AND C.SP_ID = SP.SP_ID AND SP.PRF_ID = PRF.PRF_ID AND " +
					" PRF.REG_ID = R.REG_ID ORDER BY P.PERS_ID ASC;", connection);

				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@PERS_ID", id);
				connection.Open();

                cmd.ExecuteNonQuery();
                dtListeActeNaissance.Clear();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(dtListeActeNaissance);

                rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					actesDeNaissanceList.PERS_ID = Convert.ToInt64(rdr["PERS_ID"]);
					actesDeNaissanceList.PERS_NOM = rdr["PERS_NOM"].ToString();
					actesDeNaissanceList.PERS_PRENOM = rdr["PERS_PRENOM"].ToString();
					actesDeNaissanceList.PERS_NOM_COMPLET = rdr["PERS_NOM_COMPLET"].ToString();
					actesDeNaissanceList.PERS_DATE_NAISS = rdr["PERS_DATE_NAISS"].ToString();
					actesDeNaissanceList.PERS_LIEU_NAISS = rdr["PERS_LIEU_NAISS"].ToString();
					actesDeNaissanceList.ACT_NUM = Convert.ToInt64(rdr["ACT_NUM"]);
					actesDeNaissanceList.ACT_DATE_NAISS = rdr["ACT_DATE_NAISS"].ToString();
					actesDeNaissanceList.ACT_HEURE_NAISS = Convert.ToString(rdr["ACT_HEURE_NAISS"]);
					actesDeNaissanceList.ACT_LIEU_NAISS = rdr["ACT_LIEU_NAISS"].ToString();
					actesDeNaissanceList.ACT_SEXE = rdr["ACT_SEXE"].ToString();
					actesDeNaissanceList.ACT_NOM_PERE = rdr["ACT_NOM_PERE"].ToString();
					actesDeNaissanceList.ACT_PRENOM_PERE = rdr["ACT_PRENOM_PERE"].ToString();
					actesDeNaissanceList.ACT_NOM_COMPLET_PERE = rdr["ACT_NOM_COMPLET_PERE"].ToString();
					actesDeNaissanceList.ACT_NOM_MERE = rdr["ACT_NOM_MERE"].ToString();
					actesDeNaissanceList.ACT_PRENOM_MERE = rdr["ACT_PRENOM_MERE"].ToString();
					actesDeNaissanceList.ACT_NOM_COMPLET_MERE = rdr["ACT_NOM_COMPLET_MERE"].ToString();
					actesDeNaissanceList.ACT_OFFICIER_ETAT_CIVIL = rdr["ACT_OFFICIER_ETAT_CIVIL"].ToString();
					actesDeNaissanceList.ACT_ID_NATIONALITE_PERE = Convert.ToInt64(rdr["ACT_ID_NATIONALITE_PERE"].ToString());
					actesDeNaissanceList.ACT_ID_NATIONALITE_MERE = Convert.ToInt64(rdr["ACT_ID_NATIONALITE_MERE"].ToString());
				}
				connection.Close();
				//Console.WriteLine("Connection to PostgreSQL database established successfully.");
				// Votre code pour interagir avec la base de données
			}
			return actesDeNaissanceList;
		}

		public void AddActesNaissance(ActesDeNaissance actesNaissance)
		{
			connectionString();
			using (NpgsqlConnection connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("CREER_REGION", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO T_PERSONNE VALUES(@PERS_ID, @PERS_NOM, @PERS_PRENOM" +
					", @PERS_NOM_COMPLET, @PERS_DATE_NAISS, @PERS_LIEU_NAISS)", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@PERS_ID", actesNaissance.PERS_ID);
				cmd.Parameters.AddWithValue("@PERS_NOM", actesNaissance.PERS_NOM);
				cmd.Parameters.AddWithValue("@PERS_PRENOM", actesNaissance.PERS_PRENOM);
				cmd.Parameters.AddWithValue("@PERS_NOM_COMPLET", actesNaissance.PERS_NOM+" "+ actesNaissance.PERS_PRENOM);
				cmd.Parameters.AddWithValue("@PERS_DATE_NAISS", actesNaissance.PERS_DATE_NAISS);
				cmd.Parameters.AddWithValue("@PERS_LIEU_NAISS", actesNaissance.PERS_LIEU_NAISS);
				connection.Open();
				cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO T_ACTES_DE_NAISSANCE VALUES(@ACT_NUM, @ACT_DATE_NAISS, @ACT_HEURE_NAISS" +
					", @ACT_LIEU_NAISS, @ACT_SEXE, @ACT_NOM_PERE, @ACT_PRENOM_PERE, @ACT_NOM_COMPLET_PERE, @ACT_DATE_NAISS_PERE" +
					", @ACT_LIEU_NAISS_PERE, @ACT_NATIONALITE_PERE, @ACT_PROFESSION_PERE, @ACT_DOMICILE_PERE" +
					", @ACT_NOM_MERE, @ACT_PRENOM_MERE, @ACT_NOM_COMPLET_MERE, @ACT_DATE_NAISS_MERE, @ACT_LIEU_NAISS_MERE, @ACT_NATIONALITE_MERE" +
					", @ACT_PROFESSION_MERE, @ACT_DOMICILE_MERE, @ACT_OFFICIER_ETAT_CIVIL, @ACT_ID_NATIONALITE_PERE" +
					", @ACT_ID_NATIONALITE_MERE, @PERS_ID, @CEC_ID)";

				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@ACT_NUM", actesNaissance.PERS_ID);
				cmd.Parameters.AddWithValue("@ACT_DATE_NAISS", actesNaissance.PERS_DATE_NAISS);
				cmd.Parameters.AddWithValue("@ACT_HEURE_NAISS",actesNaissance.ACT_HEURE_NAISS);
				cmd.Parameters.AddWithValue("@ACT_LIEU_NAISS", actesNaissance.PERS_LIEU_NAISS);
				cmd.Parameters.AddWithValue("@ACT_SEXE", actesNaissance.ACT_SEXE);

				cmd.Parameters.AddWithValue("@ACT_NOM_PERE", actesNaissance.ACT_NOM_PERE);
				cmd.Parameters.AddWithValue("@ACT_PRENOM_PERE", actesNaissance.ACT_PRENOM_PERE);
                cmd.Parameters.AddWithValue("@ACT_NOM_COMPLET_PERE", actesNaissance.ACT_NOM_PERE + " " + actesNaissance.ACT_PRENOM_PERE);

				cmd.Parameters.AddWithValue("@ACT_DATE_NAISS_PERE", actesNaissance.ACT_DATE_NAISS_PERE);
				cmd.Parameters.AddWithValue("@ACT_LIEU_NAISS_PERE", actesNaissance.ACT_LIEU_NAISS_PERE);
				cmd.Parameters.AddWithValue("@ACT_NATIONALITE_PERE", actesNaissance.ACT_NATIONALITE_PERE);
				cmd.Parameters.AddWithValue("@ACT_PROFESSION_PERE", actesNaissance.ACT_PROFESSION_PERE);
				cmd.Parameters.AddWithValue("@ACT_DOMICILE_PERE", actesNaissance.ACT_DOMICILE_PERE);

				cmd.Parameters.AddWithValue("@ACT_NOM_MERE", actesNaissance.ACT_NOM_MERE);
				cmd.Parameters.AddWithValue("@ACT_PRENOM_MERE", actesNaissance.ACT_PRENOM_MERE);
				cmd.Parameters.AddWithValue("@ACT_NOM_COMPLET_MERE", actesNaissance.ACT_NOM_MERE + " " + actesNaissance.ACT_PRENOM_MERE);

				cmd.Parameters.AddWithValue("@ACT_DATE_NAISS_MERE", actesNaissance.ACT_DATE_NAISS_MERE);
				cmd.Parameters.AddWithValue("@ACT_LIEU_NAISS_MERE", actesNaissance.ACT_LIEU_NAISS_MERE);
				cmd.Parameters.AddWithValue("@ACT_NATIONALITE_MERE", actesNaissance.ACT_NATIONALITE_MERE);
				cmd.Parameters.AddWithValue("@ACT_PROFESSION_MERE", actesNaissance.ACT_PROFESSION_MERE);
				cmd.Parameters.AddWithValue("@ACT_DOMICILE_MERE", actesNaissance.ACT_DOMICILE_MERE);

				cmd.Parameters.AddWithValue("@ACT_OFFICIER_ETAT_CIVIL", actesNaissance.ACT_OFFICIER_ETAT_CIVIL);
				cmd.Parameters.AddWithValue("@ACT_ID_NATIONALITE_PERE", actesNaissance.ACT_ID_NATIONALITE_PERE);
				cmd.Parameters.AddWithValue("@ACT_ID_NATIONALITE_MERE", actesNaissance.ACT_ID_NATIONALITE_MERE);

				cmd.Parameters.AddWithValue("@CEC_ID", actesNaissance.CEC_ID);
				cmd.Parameters.AddWithValue("@PERS_ID", actesNaissance.PERS_ID);

				//cmd.Parameters.AddWithValue("@ARRDT_ID", actesNaissance.ARRDT_ID);

				//connection.Open();
				cmd.ExecuteNonQuery();
				connection.Close();

			}
		}

		public void UpdateActesDeNaissance(ActesDeNaissance actesNaissance)
		{
			connectionString();
			using (NpgsqlConnection connection = new NpgsqlConnection(con))
			{
				NpgsqlCommand cmd = new NpgsqlCommand("UPDATE T_PERSONNE SET PERS_ID = @PERS_ID, PERS_NOM = @PERS_NOM, PERS_PRENOM = @PERS_PRENOM" +
					", PERS_NOM_COMPLET = @PERS_NOM_COMPLET, PERS_DATE_NAISS = @PERS_DATE_NAISS, PERS_LIEU_NAISS = @PERS_LIEU_NAISS" +
					" WHERE PERS_ID = @PERS_ID", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@PERS_ID", actesNaissance.PERS_ID);
				cmd.Parameters.AddWithValue("@PERS_NOM", actesNaissance.PERS_NOM);
				cmd.Parameters.AddWithValue("@PERS_PRENOM", actesNaissance.PERS_PRENOM);
				cmd.Parameters.AddWithValue("@PERS_NOM_COMPLET", actesNaissance.PERS_NOM + " " + actesNaissance.PERS_PRENOM);
				cmd.Parameters.AddWithValue("@PERS_DATE_NAISS", Convert.ToDateTime(actesNaissance.PERS_DATE_NAISS));
				cmd.Parameters.AddWithValue("@PERS_LIEU_NAISS", actesNaissance.PERS_LIEU_NAISS);
				connection.Open();
				cmd.ExecuteNonQuery();
				//connection.Close();

				cmd.CommandText = "UPDATE T_ACTES_DE_NAISSANCE SET ACT_NUM = @ACT_NUM, ACT_DATE_NAISS = @ACT_DATE_NAISS, ACT_HEURE_NAISS = @ACT_HEURE_NAISS" +
					",ACT_LIEU_NAISS = @ACT_LIEU_NAISS, ACT_SEXE = @ACT_SEXE, ACT_NOM_PERE = @ACT_NOM_PERE, ACT_PRENOM_PERE = @ACT_PRENOM_PERE" +
					", ACT_NOM_COMPLET_PERE = @ACT_NOM_COMPLET_PERE, ACT_NOM_MERE = @ACT_NOM_MERE, ACT_PRENOM_MERE = @ACT_PRENOM_MERE" +
					", ACT_NOM_COMPLET_MERE = @ACT_NOM_COMPLET_MERE, ACT_OFFICIER_ETAT_CIVIL = @ACT_OFFICIER_ETAT_CIVIL, ACT_ID_NATIONALITE_PERE = @ACT_ID_NATIONALITE_PERE" +
					", ACT_ID_NATIONALITE_MERE = @ACT_ID_NATIONALITE_MERE, PERS_ID = @PERS_ID, CEC_ID = @CEC_ID WHERE PERS_ID = @PERS_ID";
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@ACT_NUM", actesNaissance.PERS_ID);
				cmd.Parameters.AddWithValue("@ACT_DATE_NAISS", Convert.ToDateTime(actesNaissance.PERS_DATE_NAISS));
				cmd.Parameters.AddWithValue("@ACT_HEURE_NAISS", actesNaissance.ACT_HEURE_NAISS);
				cmd.Parameters.AddWithValue("@ACT_LIEU_NAISS", actesNaissance.PERS_LIEU_NAISS);
				cmd.Parameters.AddWithValue("@ACT_SEXE", actesNaissance.ACT_SEXE);
				cmd.Parameters.AddWithValue("@ACT_NOM_PERE", actesNaissance.ACT_NOM_PERE);
				cmd.Parameters.AddWithValue("@ACT_PRENOM_PERE", actesNaissance.ACT_PRENOM_PERE);
				cmd.Parameters.AddWithValue("@ACT_NOM_COMPLET_PERE", actesNaissance.ACT_NOM_PERE + " " + actesNaissance.ACT_PRENOM_PERE);
				cmd.Parameters.AddWithValue("@ACT_NOM_MERE", actesNaissance.ACT_NOM_MERE);
				cmd.Parameters.AddWithValue("@ACT_PRENOM_MERE", actesNaissance.ACT_PRENOM_MERE);
				cmd.Parameters.AddWithValue("@ACT_NOM_COMPLET_MERE", actesNaissance.ACT_NOM_MERE + " " + actesNaissance.ACT_PRENOM_MERE);
				cmd.Parameters.AddWithValue("@ACT_OFFICIER_ETAT_CIVIL", actesNaissance.ACT_OFFICIER_ETAT_CIVIL);
				cmd.Parameters.AddWithValue("@ACT_ID_NATIONALITE_PERE", actesNaissance.ACT_ID_NATIONALITE_PERE);
				cmd.Parameters.AddWithValue("@ACT_ID_NATIONALITE_MERE", actesNaissance.ACT_ID_NATIONALITE_MERE);

				cmd.Parameters.AddWithValue("@CEC_ID", actesNaissance.CEC_ID);
				cmd.Parameters.AddWithValue("@PERS_ID", actesNaissance.PERS_ID);

				//connection.Open();
				cmd.ExecuteNonQuery();
				connection.Close();
			}
		}


		public void DeleteActesDeNaissance(int? id)
		{
			connectionString();
			using (NpgsqlConnection connection = new NpgsqlConnection(con))
			{
				NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM T_PERSONNE WHERE PERS_ID = @PERS_ID", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@PERS_ID", id);
				connection.Open();
				cmd.ExecuteNonQuery();

				cmd.CommandText = "DELETE FROM T_ACTES_DE_NAISSANCE WHERE PERS_ID = @PERS_ID";
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@PERS_ID", id);
				cmd.ExecuteNonQuery();

				connection.Close();
			}
		}

	}
}
