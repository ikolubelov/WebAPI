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
		public HttpStatusCode StatusCode { get; set; }
		public string RawResponse { get; set; }
	}
}
