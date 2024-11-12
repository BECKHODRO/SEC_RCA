using System;
using System.ComponentModel.DataAnnotations;

namespace GASEC_RCA.Data
{
	public class Nationalite
	{
		[Required]
		public Int64 NAT_ID { get; set; }
		[Required]
		public string NAT_NOM { get; set; }
	}
}
