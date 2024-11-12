using GASEC_RCA.Data;
using Npgsql;
using System.Collections.Generic;
using System;

namespace GASEC_RCA.Service
{
	public class ZoneService
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

		public IEnumerable<Zone> GetAllZoneRegion()
		{
			List<Zone> zoneList = new List<Zone>();

			connectionString();
			using (var connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("LISTE_REGION", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM  T_REGION ORDER BY REG_ID ASC;", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				connection.Open();
				NpgsqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Zone zone = new Zone();
					zone.ZONE_CODE = Convert.ToInt64(rdr["REG_ID"]);
					zone.ZONE_NOM = rdr["REG_NOM"].ToString();
					zoneList.Add(zone);
				}
				connection.Close();
				//Console.WriteLine("Connection to PostgreSQL database established successfully.");
				// Votre code pour interagir avec la base de données
			}
			return zoneList;
		}

		public IEnumerable<Zone> GetAllZonePrefecture()
		{
			List<Zone> zoneList = new List<Zone>();

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
					Zone zone = new Zone();
					zone.ZONE_CODE = Convert.ToInt64(rdr["PRF_ID"]);
					zone.ZONE_NOM = rdr["PRF_NOM"].ToString();
					zoneList.Add(zone);
				}
				connection.Close();
				//Console.WriteLine("Connection to PostgreSQL database established successfully.");
				// Votre code pour interagir avec la base de données
			}
			return zoneList;
		}

		public IEnumerable<Zone> GetAllZoneSousPrefecture()
		{
			List<Zone> zoneList = new List<Zone>();

			connectionString();
			using (var connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("LISTE_REGION", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_SOUS_PREFECTURE SP, T_PREFECTURE P WHERE SP.PRF_ID = P.PRF_ID ORDER BY SP.PRF_ID ASC;", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				connection.Open();
				NpgsqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Zone zone = new Zone();
					zone.ZONE_CODE = Convert.ToInt64(rdr["SP_ID"]);
					zone.ZONE_NOM = rdr["SP_NOM"].ToString();
					zoneList.Add(zone);
				}
				connection.Close();
				//Console.WriteLine("Connection to PostgreSQL database established successfully.");
				// Votre code pour interagir avec la base de données
			}
			return zoneList;
		}

		public IEnumerable<Zone> GetAllZoneCommune()
		{
			List<Zone> zoneList = new List<Zone>();

			connectionString();
			using (var connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("LISTE_REGION", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_COMMUNE C, T_SOUS_PREFECTURE SP WHERE C.SP_ID = SP.SP_ID ORDER BY C.CMN_ID ASC;", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				connection.Open();
				NpgsqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Zone zone = new Zone();
					zone.ZONE_CODE = Convert.ToInt64(rdr["CMN_ID"]);
					zone.ZONE_NOM = rdr["CMN_NOM"].ToString();
					zoneList.Add(zone);
				}
				connection.Close();
				//Console.WriteLine("Connection to PostgreSQL database established successfully.");
				// Votre code pour interagir avec la base de données
			}
			return zoneList;
		}

		public IEnumerable<Zone> GetAllZoneArrondissement()
		{
			List<Zone> zoneList = new List<Zone>();

			connectionString();
			using (var connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("LISTE_REGION", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_ARRONDISSEMENT A, T_COMMUNE C WHERE A.CMN_ID = C.CMN_ID ORDER BY A.ARRDT_ID ASC;", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				connection.Open();
				NpgsqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Zone zone = new Zone();
					zone.ZONE_CODE = Convert.ToInt64(rdr["ARRDT_ID"]);
					zone.ZONE_NOM = rdr["ARRDT_NOM"].ToString();
					zoneList.Add(zone);
				}
				connection.Close();
				//Console.WriteLine("Connection to PostgreSQL database established successfully.");
				// Votre code pour interagir avec la base de données
			}
			return zoneList;
		}

        public IEnumerable<Zone> GetAllZoneCEC()
        {
            List<Zone> zoneList = new List<Zone>();

            connectionString();
            using (var connection = new NpgsqlConnection(con))
            {
                //NpgsqlCommand cmd = new NpgsqlCommand("LISTE_REGION", connection);
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_CENTRE_ETAT_CIVIL CEC, T_ARRONDISSEMENT A WHERE CEC.ARRDT_ID = A.ARRDT_ID ORDER BY CEC.CEC_ID ASC;", connection);
                cmd.CommandType = System.Data.CommandType.Text;
                connection.Open();
                NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Zone zone = new Zone();
                    zone.ZONE_CODE = Convert.ToInt64(rdr["CEC_ID"]);
                    zone.ZONE_NOM = rdr["CEC_NOM"].ToString();
                    zoneList.Add(zone);
                }
                connection.Close();
                //Console.WriteLine("Connection to PostgreSQL database established successfully.");
                // Votre code pour interagir avec la base de données
            }
            return zoneList;
        }
    }
}
