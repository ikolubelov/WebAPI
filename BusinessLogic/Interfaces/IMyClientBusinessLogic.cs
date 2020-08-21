using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
	public interface IMyClientBusinessLogic
	{
		MyClientResponse StartPostingProcess(IMyClient myClient, Request preDefinedRequest, string requestId);
		//AutoBookResponse CheckBookingProcess(string hexCode, vwUsersWithPermission user, IAutoBookClient autoBookClient, TransactionTypeEnum transactionType);
	}
}
