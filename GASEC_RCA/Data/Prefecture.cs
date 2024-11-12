using System.ComponentModel.DataAnnotations;
using System;

namespace GASEC_RCA.Data
{
	public class Prefecture
	{
		public Int64 PRF_ID { get; set; }
		[Required]
		public string PRF_NOM { get; set; }
		public Int64 REG_ID { get; set; }
		public string REG_NOM { get; set; }
	}
}
