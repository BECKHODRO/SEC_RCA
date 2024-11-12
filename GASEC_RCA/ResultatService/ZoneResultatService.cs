using GASEC_RCA.Data;
using GASEC_RCA.Service;
using System.Collections.Generic;
using System.Linq;

namespace GASEC_RCA.ResultatService
{
	public class ZoneResultatService
	{
		public readonly ZoneService objZoneDAL;

		public ZoneResultatService(ZoneService zoneService)
		{
			this.objZoneDAL = zoneService;
		}

		public List<Zone> GetAllZoneRegion(/*Region objRegion*/)
		{
			List<Zone> zone = objZoneDAL.GetAllZoneRegion().ToList();
			return zone;
		}

		public List<Zone> GetAllZonePrefecture(/*Region objRegion*/)
		{
			List<Zone> zone = objZoneDAL.GetAllZonePrefecture().ToList();
			return zone;
		}

		public List<Zone> GetAllZoneSousPrefecture(/*Region objRegion*/)
		{
			List<Zone> zone = objZoneDAL.GetAllZoneSousPrefecture().ToList();
			return zone;
		}

		public List<Zone> GetAllZoneCommune(/*Region objRegion*/)
		{
			List<Zone> zone = objZoneDAL.GetAllZoneCommune().ToList();
			return zone;
		}

		public List<Zone> GetAllZoneArrdt(/*Region objRegion*/)
		{
			List<Zone> zone = objZoneDAL.GetAllZoneArrondissement().ToList();
			return zone;
		}

        public List<Zone> GetAllZoneCEC(/*Region objRegion*/)
        {
            List<Zone> zone = objZoneDAL.GetAllZoneCEC().ToList();
            return zone;
        }

    }
}
