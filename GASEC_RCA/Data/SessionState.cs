using System;

namespace GASEC_RCA.Data
{
    public class SessionState
    {
        public Int64 sessionIdUser { get; set; }
        public string sessionNom { get; set; }
        public string sessionLogin { get; set; }
        public Int64 sessionIdGeo { get; set; }
        public Int64 sessionIdZone { get; set; }


        public Int64 sessionIdCEC { get; set; }
        public string sessionNomCEC { get; set; }
        public string sessionArrdt { get; set; }
		public string sessionCommune { get; set; }
		public string sessionSousPrefecture { get; set; }
		public string sessionPrefecture { get; set; }
		public string sessionRegion { get; set; }
		public int sessionEtat { get; set; }
    }
}
