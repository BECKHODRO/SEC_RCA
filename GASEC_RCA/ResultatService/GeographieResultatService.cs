using GASEC_RCA.Data;
using GASEC_RCA.Service;
using System.Collections.Generic;
using System.Linq;

namespace GASEC_RCA.ResultatService
{
	public class GeographieResultatService
	{
		public readonly GeographieService objGeographieDAL;

		public GeographieResultatService(GeographieService geographieService)
		{
			objGeographieDAL = geographieService;
		}

		public List<Geographie> GetAllGeographie(/*Region objRegion*/)
		{
			List<Geographie> geographie = objGeographieDAL.GetAllGeographie().ToList();
			return geographie;
		}
	}
}
