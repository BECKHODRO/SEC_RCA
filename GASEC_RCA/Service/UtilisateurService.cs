
using GASEC_RCA.Data;
using Microsoft.AspNetCore.Hosting.Server;
using System;
using Npgsql;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;

namespace GASEC_RCA.Service
{
	public class UtilisateurService
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

		public IEnumerable<Utilisateur> GetAllUtilisateur()
		{
			List<Utilisateur> utilisateurList = new List<Utilisateur>();

			connectionString();
			using (var connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("LISTE_REGION", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_UTILISATEUR U, T_ROLE R WHERE U.RLE_ID = R.RLE_ID ORDER BY U.UTIL_ID ASC;", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				connection.Open();
				NpgsqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Utilisateur utilisateur = new Utilisateur();
					utilisateur.UTIL_ID = Convert.ToInt64(rdr["UTIL_ID"]);
					utilisateur.UTIL_NOM_COMPLET = rdr["UTIL_NOM_COMPLET"].ToString();
					utilisateur.UTIL_LOGIN = rdr["UTIL_LOGIN"].ToString();
					utilisateur.UTIL_EMAIL = rdr["UTIL_EMAIL"].ToString();
					utilisateur.RLE_ID = Convert.ToInt64(rdr["RLE_ID"]);
					utilisateur.RLE_NOM = rdr["RLE_NOM"].ToString();
					utilisateur.UTIL_STATUT = 1;
					utilisateur.GEO_ID = Convert.ToInt64(rdr["GEO_ID"]);
					utilisateur.CODE_ZONE = Convert.ToInt64(rdr["CODE_ZONE"]);
					utilisateurList.Add(utilisateur);
				}
				connection.Close();
				//Console.WriteLine("Connection to PostgreSQL database established successfully.");
				// Votre code pour interagir avec la base de données
			}
			return utilisateurList;
		}

		public void AddUser(Utilisateur utilisateur)
		{
			connectionString();
			using (NpgsqlConnection connection = new NpgsqlConnection(con))
			{
				//NpgsqlCommand cmd = new NpgsqlCommand("CREER_REGION", connection);
				NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO T_UTILISATEUR VALUES(@UTIL_ID, @UTIL_NOM, @UTIL_PRENOM, @UTIL_NOM_COMPLET" +
					", @UTIL_LOGIN, @UTIL_PWD, @UTIL_EMAIL, @RLE_ID, @UTIL_STATUT, @GEO_ID, @CODE_ZONE)", connection);
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.Parameters.AddWithValue("@UTIL_ID", utilisateur.UTIL_ID);
				cmd.Parameters.AddWithValue("@UTIL_NOM", utilisateur.UTIL_NOM);
				cmd.Parameters.AddWithValue("@UTIL_PRENOM", utilisateur.UTIL_PRENOM);
				cmd.Parameters.AddWithValue("@UTIL_NOM_COMPLET", utilisateur.UTIL_NOM +" "+ utilisateur.UTIL_PRENOM);
				cmd.Parameters.AddWithValue("@UTIL_LOGIN", utilisateur.UTIL_LOGIN);
				cmd.Parameters.AddWithValue("@UTIL_PWD", utilisateur.UTIL_PWD);
				cmd.Parameters.AddWithValue("@UTIL_EMAIL", utilisateur.UTIL_EMAIL);
				cmd.Parameters.AddWithValue("@RLE_ID", utilisateur.RLE_ID);
				cmd.Parameters.AddWithValue("@UTIL_STATUT", utilisateur.UTIL_STATUT);
				cmd.Parameters.AddWithValue("@GEO_ID", utilisateur.GEO_ID);
				cmd.Parameters.AddWithValue("@CODE_ZONE", utilisateur.CODE_ZONE);

				connection.Open();
				cmd.ExecuteNonQuery();
				connection.Close();
			}
		}

	}
}
