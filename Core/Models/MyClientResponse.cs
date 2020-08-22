using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Core.Models
{
	public class MyClientResponse
	{
		public MyClientResponse() {}

		public MyClientResponse(MyClientResponseTypes responseType)
		{
			ResponseType = responseType;
		}

		public MyClientResponseTypes ResponseType { get; set; }
		public HttpStatusCode RequestStatus { get; set; }
		public string Detail { get; set; }
		public string Body { get; set; }
	}
}
