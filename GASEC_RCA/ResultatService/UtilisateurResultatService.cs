using GASEC_RCA.Data;
using GASEC_RCA.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GASEC_RCA.ResultatService
{
	public class UtilisateurResultatService
	{

		public readonly UtilisateurService objUtilisateurDAL;

		public UtilisateurResultatService(UtilisateurService utilisateurService)
		{
			this.objUtilisateurDAL = utilisateurService;
		}

		public string create(Utilisateur objUtilisateur)
		{
			objUtilisateurDAL.AddUser(objUtilisateur);
			return "Ajouter avec succcès";
		}

		public List<Utilisateur> GetAllUtilisateur(/*Region objRegion*/)
		{
			List<Utilisateur> utilisateurs = objUtilisateurDAL.GetAllUtilisateur().ToList();
			return utilisateurs;
		}

	}
}
