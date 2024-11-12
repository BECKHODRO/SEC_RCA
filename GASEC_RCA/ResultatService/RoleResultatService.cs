using GASEC_RCA.Data;
using GASEC_RCA.Service;
using System.Collections.Generic;
using System.Linq;

namespace GASEC_RCA.ResultatService
{
	public class RoleResultatService
	{
		public readonly RoleServices objRoleDAL;

		public RoleResultatService(RoleServices roleService)
		{
			objRoleDAL = roleService;
		}

		public List<Role> GetAllRole(/*Region objRegion*/)
		{
			List<Role> roles = objRoleDAL.GetAllRole().ToList();
			return roles;
		}

	}
}
