using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
	public interface IMyClientBusinessLogic
	{
		MyClientResponse StartPostingProcess(IMyClient myClient, Request preDefinedRequest, string requestId);
		MyClientResponse CheckRequestStatus(IMyClient myClient, string requestId);
	}
}
