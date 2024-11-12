using GASEC_RCA.Data;
using GASEC_RCA.Service;
using Npgsql;
using System.Collections.Generic;
using System;
using System.Linq;

namespace GASEC_RCA.ResultatService
{
    public class PersonneResultatService
    {
        public readonly PersonneService objPersonneDAL;

        public PersonneResultatService(PersonneService personneService)
        {
            objPersonneDAL = personneService;
        }

        public List<Personne> GetAllPersonne(/*Region objRegion*/)
        {
            List<Personne> personnes = objPersonneDAL.GetAllPersonne().ToList();
            return personnes;
        }

    }
}
