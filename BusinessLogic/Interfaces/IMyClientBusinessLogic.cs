using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
	public interface IMyClientBusinessLogic
	{
		string StartPostingProcess(IMyClient myClient, MyRequest preDefinedRequest, string requestId);
		Task<MyClientAPIResponse> CheckRequestStatus(IMyClient myClient, string requestId);
	}
}
