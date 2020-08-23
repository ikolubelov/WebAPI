using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interfaces;
using Core.Models;

namespace BusinessLogic.Interfaces
{
	public interface IMyTaskBusinessLogic
	{
		string PostData(MyRequest request);
		void ProcessCallBack(string requestId, string status);
		MyClientAPIResponse CheckRequestStatus(string requestId);
		void SendRequestStatus(string requestId, MyClientAPIResponse myClientResponse);
	}
}
