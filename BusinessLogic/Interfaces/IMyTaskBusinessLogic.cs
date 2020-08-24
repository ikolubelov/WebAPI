using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Core.Models;

namespace BusinessLogic.Interfaces
{
	public interface IMyTaskBusinessLogic
	{
		string PostData(MyRequest request);
		void ProcessCallBack(string requestId, string status);
		Task<MyClientAPIResponse> CheckRequestStatus(string requestId);
		void UpdateRequestStatus(string requestId, MyClientAPIResponse myClientResponse);
	}
}
