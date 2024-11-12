using System.ComponentModel.DataAnnotations;
using System;

namespace GASEC_RCA.Data
{
	public class Role
	{
		public Int64 RLE_ID { get; set; }
		[Required]
		public string RLE_NOM { get; set; }
	}
}
