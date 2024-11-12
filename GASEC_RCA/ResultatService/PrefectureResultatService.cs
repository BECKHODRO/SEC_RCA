using GASEC_RCA.Data;
using GASEC_RCA.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GASEC_RCA.ServiceResultat
{
	public class PrefectureResultatService
	{
		public readonly PrefectureQuery objPrefectureDAL;
		public PrefectureResultatService(PrefectureQuery prefectureService)
		{
			this.objPrefectureDAL = prefectureService;
		}

		public string create(Prefecture objPrefecture)
		{
			objPrefectureDAL.AddPrefecture(objPrefecture);
			return "Ajouter avec succcès";
		}

		public List<Prefecture> GetAllPrefecture(/*Region objRegion*/)
		{
			List<Prefecture> prefectures = objPrefectureDAL.GetAllPrefecture().ToList();
			return prefectures;
		}

		public Prefecture GetPrefectureByID(int id)
		{
			Prefecture prefectures = objPrefectureDAL.GetPrefectureDataByID(id);
			return prefectures;
		}

		public string UptdatePrefecture(Prefecture objPrefecture)
		{
			objPrefectureDAL.UpdatePrefecture(objPrefecture);
			return "Modifier avec succcès";
		}

		public string DeletePrefecture(Prefecture objPrefecture)
		{
			objPrefectureDAL.DeletePrefecture(Convert.ToInt32(objPrefecture.PRF_ID));
			return "Modifier avec succcès";
		}

	}
}
