using GASEC_RCA.Data;
using GASEC_RCA.Service;
using System.Collections.Generic;
using System.Linq;

namespace GASEC_RCA.ResultatService
{
	public class NationaliteResultatService
	{
		public readonly NationaliteService objNationaliteDAL;

		public NationaliteResultatService(NationaliteService nationaliteService)
		{
			objNationaliteDAL = nationaliteService;
		}

		public string create(Nationalite objNationalite)
		{
			objNationaliteDAL.AddNationalite(objNationalite);
			return "Ajouter avec succcès";
		}

		public List<Nationalite> GetAllNationalite(/*Region objRegion*/)
		{
			List<Nationalite> nationalite = objNationaliteDAL.GetAllNatonalite().ToList();
			return nationalite;
		}

		public Nationalite GetRegionByID(int id)
		{
			Nationalite nationalite = objNationaliteDAL.GetNationaliteDataByID(id);
			return nationalite;
		}

		//public string UptdateRegion(Region objRegion)
		//{
		//	objRegionDAL.UpdateRegion(objRegion);
		//	return "Modifier avec succcès";
		//}
	}
}
