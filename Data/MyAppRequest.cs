using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data
{
	[Table("MyAppRequest")]
	public partial class MyAppRequest
	{
		[Key]
		[StringLength(50)]
		public string RequestId { get; set; }

		[StringLength(25)]
		public string Status { get; set; }

		[StringLength(5000)]
		public string Details { get; set; }

		[Required]
		[StringLength(50)]
		public string InsertedBy { get; set; }

		[Column(TypeName = "datetime2")]
		public DateTime InsertDate { get; set; }

		[Required]
		[StringLength(50)]
		public string UpdatedBy { get; set; }

		[Column(TypeName = "datetime2")]
		public DateTime UpdatedDate { get; set; }

	}
}
