using GASEC_RCA.Data;
using GASEC_RCA.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GASEC_RCA.ResultatService
{
	public class ActesMariageResultatService
	{
		public readonly ActesMariageService objActesMariageDAL;



		public ActesMariageResultatService(ActesMariageService actesMariageService)
		{
			objActesMariageDAL = actesMariageService;
		}

		public string create(ActesDeMariage objActesDeMariage)
		{
			objActesMariageDAL.AddActesNaissance(objActesDeMariage);
			return "Ajouter avec succcès";
		}

		//public List<ActesDeNaissance> GetAllActesNaissance(/*Region objRegion*/)
		//{
		//	List<ActesDeNaissance> actesDeNaissance = objActesMariageDAL.GetAllActesNaissance().ToList();
		//	return actesDeNaissance;
		//}

		//public ActesDeNaissance GetActesDeNaissanceByID(int id)
		//{
		//	ActesDeNaissance actesDeNaissances = objActesMariageDAL.GetActesDeNaissanceByID(id);
		//	return actesDeNaissances;
		//}


	}


}
