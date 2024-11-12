using GASEC_RCA.Data;
using Npgsql;
using System.Collections.Generic;
using System;

namespace GASEC_RCA.Service
{
	public class GeographieService
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
		public IEnumerable<Geographie> GetAllGeographie()
		{
			List<Geographie> geographieList = new List<Geographie>();

			connectionString();
			using (var connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("LISTE_REGION", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_GEOGRAPHIE ORDER BY GEO_ID ASC;", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				connection.Open();
				NpgsqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Geographie geographie = new Geographie();
					geographie.GEO_ID = Convert.ToInt64(rdr["GEO_ID"]);
					geographie.GEO_NOM = rdr["GEO_NOM"].ToString();
					geographieList.Add(geographie);
				}
				connection.Close();
				//Console.WriteLine("Connection to PostgreSQL database established successfully.");
				// Votre code pour interagir avec la base de données
			}
			return geographieList;
		}
	}
}
