using GASEC_RCA.Data;
using GASEC_RCA.Service;
using System.Collections.Generic;
using System.Linq;

namespace GASEC_RCA.ResultatService
{
    public class AuthentificationResultatService
    {
        public readonly AuthentificationService objAuthentificationDAL;

        public AuthentificationResultatService(AuthentificationService authentificationService)
        {
            this.objAuthentificationDAL = authentificationService;
        }

        public List<Authentification> GetAllAuthentification(/*Region objRegion*/)
        {
            List<Authentification> authentification = objAuthentificationDAL.GetAllAuthentification().ToList();
            return authentification;
        }

        public List<Zone> GetAllZoneRegion(/*Region objRegion*/)
        {
            List<Zone> zone = objAuthentificationDAL.GetAllZoneRegion().ToList();
            return zone;
        }

        public List<Zone> GetAllZonePrefecture(/*Region objRegion*/)
        {
            List<Zone> zone = objAuthentificationDAL.GetAllZonePrefecture().ToList();
            return zone;
        }

        public List<Zone> GetAllZoneSousPrefecture(/*Region objRegion*/)
        {
            List<Zone> zone = objAuthentificationDAL.GetAllZoneSousPrefecture().ToList();
            return zone;
        }

        public List<Zone> GetAllZoneCommune(/*Region objRegion*/)
        {
            List<Zone> zone = objAuthentificationDAL.GetAllZoneCommune().ToList();
            return zone;
        }

        public List<Zone> GetAllZoneArrdt(/*Region objRegion*/)
        {
            List<Zone> zone = objAuthentificationDAL.GetAllZoneArrondissement().ToList();
            return zone;
        }

        public List<Zone> GetAllZoneCEC(/*Region objRegion*/)
        {
            List<Zone> zone = objAuthentificationDAL.GetAllZoneCEC().ToList();
            return zone;
        }


    }
}
