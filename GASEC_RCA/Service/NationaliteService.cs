using GASEC_RCA.Data;
using Npgsql;
using System.Collections.Generic;
using System;

namespace GASEC_RCA.Service
{
	public class NationaliteService
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

		public IEnumerable<Nationalite> GetAllNatonalite()
		{
			List<Nationalite> nationaliteList = new List<Nationalite>();

			connectionString();
			using (var connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("LISTE_REGION", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_NATIONALITE ORDER BY NAT_ID ASC;", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				connection.Open();
				NpgsqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Nationalite nationalite = new Nationalite();
					nationalite.NAT_ID = Convert.ToInt64(rdr["NAT_ID"]);
					nationalite.NAT_NOM = rdr["NAT_NOM"].ToString();
					nationaliteList.Add(nationalite);
				}
				connection.Close();
				//Console.WriteLine("Connection to PostgreSQL database established successfully.");
				// Votre code pour interagir avec la base de données
			}
			return nationaliteList;
		}

		public Nationalite GetNationaliteDataByID(int? id)
		{
			Nationalite nationaliteList = new Nationalite();

			connectionString();
			using (var connection = new NpgsqlConnection(con))
			{
				NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_NATIONALITE WHERE NAT_ID = @NAT_ID ORDER BY NAT_ID ASC;", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@NAT_ID", id);
				connection.Open();
				NpgsqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{

					nationaliteList.NAT_ID = Convert.ToInt64(rdr["NAT_ID"]);
					nationaliteList.NAT_NOM = rdr["NAT_NOM"].ToString();
				}
				connection.Close();
				//Console.WriteLine("Connection to PostgreSQL database established successfully.");
				// Votre code pour interagir avec la base de données
			}
			return nationaliteList;
		}

		public void AddNationalite(Nationalite nationalite)
		{
			connectionString();
			using (NpgsqlConnection connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("CREER_REGION", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO T_NATIONALITE VALUES(@NAT_ID, @NAT_NOM)", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@NAT_ID", nationalite.NAT_ID);
				cmd.Parameters.AddWithValue("@NAT_NOM", nationalite.NAT_NOM);
				connection.Open();
				cmd.ExecuteNonQuery();
				connection.Close();
			}
		}

		public void UpdateRegion(Region region)
		{
			connectionString();
			using (NpgsqlConnection connection = new NpgsqlConnection(con))
			{
				NpgsqlCommand cmd = new NpgsqlCommand("UPDATE T_REGION SET REG_NOM = @REG_NOM WHERE REG_ID = @REG_ID", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@REG_ID", region.REG_ID);
				cmd.Parameters.AddWithValue("@REG_NOM", region.REG_NOM);
				connection.Open();
				cmd.ExecuteNonQuery();
				connection.Close();
			}
		}


		public void DeleteRegion(int? id)
		{
			connectionString();
			using (NpgsqlConnection connection = new NpgsqlConnection(con))
			{
				NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM T_REGION WHERE REG_ID = @REG_ID", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@REG_ID", id);
				connection.Open();
				cmd.ExecuteNonQuery();
				connection.Close();
			}
		}

	}
}
