using Core.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Core.Models
{
	public class MyClientAPIResponse
	{
		[JsonProperty("Status")]
		public string Status { get; set; }

		[JsonProperty("Detail")]
		public string Detail { get; set; }

		[JsonProperty("Body")]
		public string Body { get; set; }

		[JsonProperty("LastActionDate")]
		public string LastActionDate { get; set; }
	}
}
