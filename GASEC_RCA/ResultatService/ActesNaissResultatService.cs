using GASEC_RCA.Data;
using GASEC_RCA.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GASEC_RCA.ResultatService
{
    public class ActesNaissResultatService
    {
        public readonly ActesNaissService objActesNaissDAL;

        public ActesNaissResultatService(ActesNaissService actesNaissService)
        {
            objActesNaissDAL = actesNaissService;
        }

		public string create(ActesDeNaissance objActesDeNaissance)
		{
			objActesNaissDAL.AddActesNaissance(objActesDeNaissance);
			return "Ajouter avec succcès";
		}

		public List<ActesDeNaissance> GetAllActesNaissance(/*Region objRegion*/)
        {
            List<ActesDeNaissance> actesDeNaissance = objActesNaissDAL.GetAllActesNaissance().ToList();
            return actesDeNaissance;
        }

		public ActesDeNaissance GetActesDeNaissanceByID(int id)
		{
			ActesDeNaissance actesDeNaissances = objActesNaissDAL.GetActesDeNaissanceByID(id);
			return actesDeNaissances;
		}

		public string Update(ActesDeNaissance objActesDeNaissance)
		{
			objActesNaissDAL.UpdateActesDeNaissance(objActesDeNaissance);
			return "Modifier avec succcès";
		}

		public string Delete(ActesDeNaissance objActesDeNaissance)
		{
			objActesNaissDAL.DeleteActesDeNaissance(Convert.ToInt32(objActesDeNaissance.PERS_ID));
			return "Modifier avec succcès";
		}

	}
}
