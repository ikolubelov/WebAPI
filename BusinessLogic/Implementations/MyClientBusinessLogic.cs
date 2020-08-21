using BusinessLogic.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BusinessLogic.Implementations
{

	//this is client(third-party service) related class
	//any business logic related to client before sending request should go here
	public class MyClientBusinessLogic : IMyClientBusinessLogic
	{

		/// <summary>
		/// This method calls third-party service and sends request
		/// Client will process request within few days. This is why we are 
		/// just posting data and only check is to make sure that request submitted successfuly
		/// </summary>
		/// <param name="request">client details, request sent from front-end, request id</param>
		/// <returns>status of request</returns>
		public MyClientResponse StartPostingProcess(IMyClient myClient,
													Request preDefinedRequest,
													string requestId)
		{
			var request = new MyClientRequest()
			{
				Body = preDefinedRequest,
				CallBackUrl = $"api/MyTask/CallBack/{requestId}" //Since this is an exercise it is ok to have hard coded values 
			};

			//calling third party service
			//PLEASE NOTE: 
			//In real scenario client response could have more properties (e.g. DisplayMessage, RawResponse, RequestURL etc.)
			//For the purpose of this exercise client Response has only one property called status which will be returned to the initial caller
			var response = myClient.PostData(request);

			if (response.Status == "BAD REQUEST" || response.Status == "ERROR SENDING REQUEST")
			{
				//this is the part where we can create error handler class and take care of errors
				//based on requirements we can log error and other details
			}
			else if (response.Status == "OK")
			{
				//this is the part where we can create handler success class
				//if request is successful - we will save request id and other details in the database
				//repository method needs to be called in order to save details
			}

			return response;
		}

		public MyClientResponse CheckRequestStatus(IMyClient myClient, string requestId)
		{
			return null;
		}
		}
}
