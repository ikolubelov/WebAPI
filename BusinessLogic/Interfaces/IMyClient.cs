using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
	public interface IMyClient
	{
		MyClientResponse PostData(MyClientRequest request);

		//MyClientResponses CheckStatus(AutoBookRequest request, AutoBookClientSetupModel settings);

		//MyClientResponses HandleAutoBookRequest(string url, AutoBookRequest abRequest, Method method, AutoBookClientSetupModel settings);
	}
}
