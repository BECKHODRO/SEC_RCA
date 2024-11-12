namespace GASEC_RCA.Data
{
	public class Connexion
	{

		public string SERVEUR { get; set; }
		public string BDD { get; set; }
		public string lienCnx;
		public void chaineDeConnexion()
		{
			//public string lienCnx = "data source=WINSVR2019;database=PROSCOL;integrated security=SSPI;";
			lienCnx = "Server=localhost;Port=5433;Database=GASEC;User Id=postgres;Password=Beckos@2212;";

			//public string lienCnx = "data source=192.168.50.100,1433;database=PROSCOL;integrated security=SSPI;";
			//public string lienCnx = @"data source=WINSRV2019\WINSRV2019;database=GESCAISSE_BDD;integrated security=SSPI;";

		}

		//public string connectionString = "data source=DESKTOP-QHL3UP9;database=YTDB;Integrated Security=SSPI";
	}
}
