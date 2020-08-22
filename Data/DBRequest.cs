using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
	public class DBRequest
	{
		public Guid RequestId { get; set; }
		public string Status { get; set; }
		public string Details { get; set; }
	}
}
