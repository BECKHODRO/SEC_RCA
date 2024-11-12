using GASEC_RCA.Data;
using GASEC_RCA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
namespace GASEC_RCA.ServiceResultat
{
	public class RegionResultatService
	{
		public readonly RegionService objRegionDAL;

		public RegionResultatService(RegionService regionService) 
		{
			objRegionDAL = regionService;
		}

		public string create(Region objRegion)
		{
			objRegionDAL.AddRegion(objRegion);
			return "Ajouter avec succcès";
		}

		public List<Region> GetAllRegion(/*Region objRegion*/)
		{
			List<Region> regions = objRegionDAL.GetAllRegion().ToList();
			return regions;
		}

		public Region GetRegionByID(int id)
		{
			Region regions = objRegionDAL.GetRegionDataByID(id);
			return regions;
		}

		public string UptdateRegion(Region objRegion)
		{
			objRegionDAL.UpdateRegion(objRegion);
			return "Modifier avec succcès";
		}

		public string DeleteRegion(Region objRegion)
		{
			objRegionDAL.DeleteRegion( Convert.ToInt32(objRegion.REG_ID));
			return "Modifier avec succcès";
		}
	}
}
