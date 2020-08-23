using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
	public interface IMyClientBusinessLogic
	{
		string StartPostingProcess(IMyClient myClient, MyRequest preDefinedRequest, string requestId);
		MyClientAPIResponse CheckRequestStatus(IMyClient myClient, string requestId);
	}
}
