using System;
using System.ComponentModel.DataAnnotations;

namespace GASEC_RCA.Data
{
	public class Region
	{
		public Int64 REG_ID { get; set; }
		[Required]
		public string REG_NOM { get; set; }
	}
}
