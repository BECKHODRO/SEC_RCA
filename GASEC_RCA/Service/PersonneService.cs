using GASEC_RCA.Data;
using Npgsql;
using System.Collections.Generic;
using System;

namespace GASEC_RCA.Service
{
    public class PersonneService
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

        public IEnumerable<Personne> GetAllPersonne()
        {
            List<Personne> personneList = new List<Personne>();

            connectionString();
            using (var connection = new NpgsqlConnection(con))
            {
                //NpgsqlCommand cmd = new NpgsqlCommand("LISTE_REGION", connection);
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM T_PERSONNE ORDER BY PERS_ID ASC;", connection);
                cmd.CommandType = System.Data.CommandType.Text;
                connection.Open();
                NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Personne personne = new Personne();
                    personne.PERS_ID = Convert.ToInt64(rdr["REG_ID"]);
                    personne.PERS_NOM = rdr["PERS_NOM"].ToString();
                    personne.PERS_PRENOM = rdr["PERS_PRENOM"].ToString();
                    personne.PERS_NOM_COMPLET = rdr["PERS_NOM_COMPLET"].ToString();
                    personne.PERS_DATE_NAISS = Convert.ToDateTime(rdr["PERS_DATE_NAISS"]);
                    personne.PERS_LIEU_NAISS = rdr["PERS_LIEU_NAISS"].ToString();
                    personneList.Add(personne);
                }
                connection.Close();
                //Console.WriteLine("Connection to PostgreSQL database established successfully.");
                // Votre code pour interagir avec la base de données
            }
            return personneList;
        }
    }
}
