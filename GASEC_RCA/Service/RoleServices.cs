using GASEC_RCA.Data;
using Npgsql;
using System.Collections.Generic;
using System;

namespace GASEC_RCA.Service
{
	public class RoleServices
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

		public IEnumerable<Role> GetAllRole()
		{
			List<Role> roleList = new List<Role>();

			connectionString();
			using (var connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("LISTE_REGION", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_ROLE ORDER BY RLE_ID ASC;", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				connection.Open();
				NpgsqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Role role = new Role();
					role.RLE_ID = Convert.ToInt64(rdr["RLE_ID"]);
					role.RLE_NOM = rdr["RLE_NOM"].ToString();
					roleList.Add(role);
				}
				connection.Close();
				//Console.WriteLine("Connection to PostgreSQL database established successfully.");
				// Votre code pour interagir avec la base de données
			}
			return roleList;
		}
	}
}
