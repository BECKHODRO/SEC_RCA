using System.ComponentModel.DataAnnotations;
using System;
using GASEC_RCA.Data;
using GASEC_RCA.Service;
using Npgsql;
using System.Collections.Generic;

namespace GASEC_RCA.Service
{
	public class PrefectureQuery
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

		public IEnumerable<Prefecture> GetAllPrefecture()
		{
			List<Prefecture> prefectureList = new List<Prefecture>();

			connectionString();
			using (var connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("LISTE_REGION", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_PREFECTURE P, T_REGION R WHERE P.REG_ID = R.REG_ID ORDER BY P.PRF_ID ASC;", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				connection.Open();
				NpgsqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Prefecture prefecture = new Prefecture();
					prefecture.PRF_ID = Convert.ToInt64(rdr["PRF_ID"]);
					prefecture.PRF_NOM = rdr["PRF_NOM"].ToString();
                    prefecture.REG_ID = Convert.ToInt64(rdr["REG_ID"]);
                    prefecture.REG_NOM = rdr["REG_NOM"].ToString();
                    prefectureList.Add(prefecture);
				}
				connection.Close();
				//Console.WriteLine("Connection to PostgreSQL database established successfully.");
				// Votre code pour interagir avec la base de données
			}
			return prefectureList;
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

		public Prefecture GetPrefectureDataByID(int? id)
		{
			Prefecture prefectureList = new Prefecture();

			connectionString();
			using (var connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_PREFECTURE WHERE PRF_ID = @PRF_ID AND ORDER BY PRF_ID ASC;", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_PREFECTURE P, T_REGION R WHERE P.PRF_ID = @PRF_ID AND P.REG_ID = R.REG_ID ORDER BY P.PRF_ID ASC;", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@PRF_ID", id);
				connection.Open();
				NpgsqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					prefectureList.PRF_ID = Convert.ToInt64(rdr["PRF_ID"]);
					prefectureList.PRF_NOM = rdr["PRF_NOM"].ToString();
					prefectureList.REG_ID = Convert.ToInt64(rdr["REG_ID"]);
					prefectureList.REG_NOM = rdr["REG_NOM"].ToString();
				}
				connection.Close();
				//Console.WriteLine("Connection to PostgreSQL database established successfully.");
				// Votre code pour interagir avec la base de données
			}
			return prefectureList;
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
