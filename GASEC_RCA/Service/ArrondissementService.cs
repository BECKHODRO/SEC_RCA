using GASEC_RCA.Data;
using Npgsql;
using System;
using System.Collections.Generic;

namespace GASEC_RCA.Service
{
	public class ArrondissementService
	{

		Connexion connecter = new Connexion();
		string con;

		void connectionString()
		{
			connecter.chaineDeConnexion();
			con = connecter.lienCnx;
			//connecter.SERVEUR = SERVEUR;
			//connecter.BDD = BDD;
			//connecter.chaineDeConnexion();
			//con.ConnectionString = connecter.lienCnx;
		}

		public IEnumerable<Arrondissement> GetAllArrondissement()
		{
			List<Arrondissement> arrondissementList = new List<Arrondissement>();

			connectionString();
			using (var connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("LISTE_REGION", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_ARRONDISSEMENT A, T_COMMUNE C WHERE A.CMN_ID = C.CMN_ID ORDER BY A.ARRDT_NOM ASC;", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				connection.Open();
				NpgsqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Arrondissement arrondissement = new Arrondissement();
					arrondissement.ARRDT_ID = Convert.ToInt64(rdr["ARRDT_ID"]);
					arrondissement.ARRDT_NOM = rdr["ARRDT_NOM"].ToString();
					arrondissement.COMN_ID = Convert.ToInt64(rdr["COMN_ID"]);
				}
				connection.Close();
				//Console.WriteLine("Connection to PostgreSQL database established successfully.");
				// Votre code pour interagir avec la base de données
			}
			return arrondissementList;
		}



		public Arrondissement GetArrondissementDataByID(int? id)
		{
			Arrondissement arrondissementList = new Arrondissement();

			connectionString();
			using (var connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_PREFECTURE WHERE PRF_ID = @PRF_ID AND ORDER BY PRF_ID ASC;", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_ARRONDISSEMENT A, T_COMMUNE C WHERE A.CMN_ID = @CMN_ID AND A.COMN_ID = C.COMN_ID ORDER BY A.ARRDT_NOM ASC;", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@CMN_ID", id);
				connection.Open();
				NpgsqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					arrondissementList.ARRDT_ID = Convert.ToInt64(rdr["ARRDT_ID"]);
					arrondissementList.ARRDT_NOM = rdr["ARRDT_NOM"].ToString();
					arrondissementList.COMN_ID = Convert.ToInt64(rdr["COMN_ID"]);
				}
				connection.Close();
				//Console.WriteLine("Connection to PostgreSQL database established successfully.");
				// Votre code pour interagir avec la base de données
			}
			return arrondissementList;
		}


		public void AddPrefecture(Prefecture prefecture)
		{
			connectionString();
			using (NpgsqlConnection connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("CREER_REGION", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO T_PREFECTURE VALUES(@PRF_ID, @PRF_NOM, @REG_ID)", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@PRF_ID", prefecture.PRF_ID);
				cmd.Parameters.AddWithValue("@PRF_NOM", prefecture.PRF_NOM);
				cmd.Parameters.AddWithValue("@REG_ID", prefecture.REG_ID);
				connection.Open();
				cmd.ExecuteNonQuery();
				connection.Close();
			}
		}

		

		public void UpdatePrefecture(Prefecture prefecture)
		{
			connectionString();
			using (NpgsqlConnection connection = new NpgsqlConnection(con))
			{
				NpgsqlCommand cmd = new NpgsqlCommand("UPDATE T_PREFECTURE SET PRF_NOM = @PRF_NOM, REG_ID = @REG_ID WHERE PRF_ID = @PRF_ID", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@PRF_ID", prefecture.PRF_ID);
				cmd.Parameters.AddWithValue("@PRF_NOM", prefecture.PRF_NOM);
				cmd.Parameters.AddWithValue("@REG_ID", prefecture.REG_ID);
				connection.Open();
				cmd.ExecuteNonQuery();
				connection.Close();
			}
		}

		public void DeletePrefecture(int? id)
		{
			connectionString();
			using (NpgsqlConnection connection = new NpgsqlConnection(con))
			{
				NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM T_PREFECTURE WHERE PRF_ID = @PRF_ID", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@PRF_ID", id);
				connection.Open();
				cmd.ExecuteNonQuery();
				connection.Close();
			}
		}

	}
}
