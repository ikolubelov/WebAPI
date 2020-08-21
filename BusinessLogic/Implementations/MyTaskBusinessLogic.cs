using System;
using System.Net;
using BusinessLogic.Interfaces;
using Core.Enums;
using Core.Models;

namespace BusinessLogic.Implementations
{
	//This class is intend to handle some business logic before calling Client
	//This might be an overkill for this exercise.
	//But the goal is to minimize any business logic in controller and have it in a separate tier.
	public class MyTaskBusinessLogic : IMyTaskBusinessLogic
	{
		private readonly IMyClient MyClient;
		private readonly IMyClientBusinessLogic MyClientBusinessLogic;

		public MyTaskBusinessLogic(IMyClient myClient, IMyClientBusinessLogic myClientBusinessLogic)
		{
			MyClient = myClient;
			MyClientBusinessLogic = myClientBusinessLogic;
		}

		/// <summary>
		/// This method posts data sent from front-end to client
		/// </summary>
		/// <param name="request">payload details</param>
		/// <returns>status of request</returns>
		public string PostData(Request request)
		{
			//generate unique id
			var requestId = Guid.NewGuid().ToString();

			return MyClientBusinessLogic.StartPostingProcess(MyClient, request, requestId).ResponseType == MyClientResponseTypes.Success ? "SUCCESS" : "ERROR";
		}

		/// <summary>
		/// This method is called by third-party service to
		/// notify that process started
		/// </summary>
		/// <param name="requestId">unique identifier for request</param>
		/// <returns>status of request</returns>
		public string ProcessCallBack(string requestId)
		{
			//check if requestid is valid
			if(string.IsNullOrWhiteSpace(requestId))
			{
				return "REQUEST DOES NOT EXIST";
			}

			//i would select request from db by calling repository method
			//i would update status to "started" and call repository to save new status
			//if no errors then return
			return "STARTED";
		}

		/// <summary>
		/// This method calls third-party service to check status of request
		/// </summary>
		/// <param name="requestId">unique identifier for request</param>
		/// <returns>client response object</returns>
		public MyClientResponse CheckRequestStatus(string requestId)
		{
			//here we can check of this is valid request and if it exists in db

			return MyClientBusinessLogic.CheckRequestStatus(MyClient, requestId);
		}
	}
}
