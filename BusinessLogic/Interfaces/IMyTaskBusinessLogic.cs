using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interfaces;
using Core.Models;

namespace BusinessLogic.Interfaces
{
	public interface IMyTaskBusinessLogic
	{
		string PostData(Request request);
		void ProcessCallBack(string requestId, string status);
		MyClientResponse CheckRequestStatus(string requestId);
		void UpdateRequestStatus(string requestId, MyClientResponse myClientResponse);
	}
}
