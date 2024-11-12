using GASEC_RCA.Data;
using Microsoft.AspNetCore.Hosting.Server;
using System;
using Npgsql;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;

namespace GASEC_RCA.Service
{
	public class RegionService
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

		public IEnumerable<Region> GetAllRegion()
		{
			List<Region> regionList = new List<Region> ();

			connectionString();
			using (var connection = new NpgsqlConnection(con))
			{
                //NpgsqlCommand cmd = new NpgsqlCommand("LISTE_REGION", connection);
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_REGION ORDER BY REG_ID ASC;", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				connection.Open();
				NpgsqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Region region = new Region();
					region.REG_ID = Convert.ToInt64(rdr["REG_ID"]);
					region.REG_NOM = rdr["REG_NOM"].ToString();
					regionList.Add(region);
				}
				connection.Close();
				//Console.WriteLine("Connection to PostgreSQL database established successfully.");
				// Votre code pour interagir avec la base de données
			}
			return regionList;
		}

		public Region GetRegionDataByID(int? id)
		{
			Region regionList = new Region();

			connectionString();
			using (var connection = new NpgsqlConnection(con))
			{
				NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_REGION WHERE REG_ID = @REG_ID ORDER BY REG_ID ASC;", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@REG_ID", id);
				connection.Open();
				NpgsqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					regionList.REG_ID = Convert.ToInt64(rdr["REG_ID"]);
					regionList.REG_NOM = rdr["REG_NOM"].ToString();
				}
				connection.Close();
				//Console.WriteLine("Connection to PostgreSQL database established successfully.");
				// Votre code pour interagir avec la base de données
			}
			return regionList;
		}

		public void AddRegion(Region region)
		{
			connectionString();
			using (NpgsqlConnection connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("CREER_REGION", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO T_REGION VALUES(@REG_ID, @REG_NOM)", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@REG_ID", region.REG_ID);
				cmd.Parameters.AddWithValue("@REG_NOM", region.REG_NOM);
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
