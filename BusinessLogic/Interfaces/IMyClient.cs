using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
	public interface IMyClient
	{
		MyClientResponse PostData(MyClientRequest request);
		MyClientResponse CheckRequestStatus(MyClientRequest request);
	}
}
