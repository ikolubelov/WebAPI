using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
	public interface IMyClient
	{
		MyClientResponse PostData(MyClientRequest request);
		Task<MyClientResponse> CheckRequestStatus(MyClientRequest request);
	}
}
