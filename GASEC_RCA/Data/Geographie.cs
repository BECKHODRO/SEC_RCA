using System.ComponentModel.DataAnnotations;
using System;

namespace GASEC_RCA.Data
{
	public class Geographie
	{
		[Required]
		public Int64 GEO_ID { get; set; }
		[Required]
		public string GEO_NOM { get; set; }
	}
}
