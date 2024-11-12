using GASEC_RCA.Data;
using GASEC_RCA.Service;
using System.Collections.Generic;
using System.Linq;

namespace GASEC_RCA.ResultatService
{
	public class ArrondissementResultatService
	{

		public readonly ArrondissementService objArrondissementDAL;
		public ArrondissementResultatService(ArrondissementService arrondissementService)
		{
			this.objArrondissementDAL = arrondissementService;
		}

		public string create(Prefecture objPrefecture)
		{
			objArrondissementDAL.AddPrefecture(objPrefecture);
			return "Ajouter avec succcès";
		}

		public List<Arrondissement> GetAllArrondissement(/*Region objRegion*/)
		{
			List<Arrondissement> arrondissement = objArrondissementDAL.GetAllArrondissement().ToList();
			return arrondissement;
		}

		public Arrondissement GetArrondissementByID(int id)
		{
			Arrondissement arrondissement = objArrondissementDAL.GetArrondissementDataByID(id);
			return arrondissement;
		}

	}
}
