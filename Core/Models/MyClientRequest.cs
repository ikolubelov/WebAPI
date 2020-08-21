using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
	public class MyClientRequest
	{
		public Request Body { get; set; }
		public string CallBackUrl { get; set; }
	}
}
