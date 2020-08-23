using Core.Enums;
using Core.Models;
using Data;
using System.Collections.Generic;
using System.Linq;

namespace Core.Mapping
{
	/// <summary>
	/// This method contains the mapping for my request
	/// </summary>
	public static class RequestMapping
	{
		/// <summary>
		/// This method converts a POCO Clident API response object to a DB request object
		/// </summary>
		/// <param name="obj">The client API response object to convert</param>
		/// <returns>A converted DB request object</returns>
		public static MyAppRequest ToDBRequestModel(this MyClientAPIResponse obj, string requestId)
		{
			return new MyAppRequest()
			{
				RequestId = requestId,
				Details = obj.Detail,
				Status = obj.Status
			};
		}

		/// <summary>
		/// This method converts a POCO request object to a DB request object
		/// </summary>
		/// <param name="obj">Request object to convert</param>
		/// <returns>A converted DB request object</returns>
		public static MyAppRequest ToDBRequestModel(this MyRequest obj, string requestId, string status)
		{
			return new MyAppRequest()
			{
				RequestId = requestId,
				Details = obj.RequestBody,
				Status = status
			};
		}
	}
}
