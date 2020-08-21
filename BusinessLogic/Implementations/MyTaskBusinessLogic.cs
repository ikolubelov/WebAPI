using System;
using BusinessLogic.Interfaces;
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
			var requestId = Guid.NewGuid().ToString();
			return MyClientBusinessLogic.StartPostingProcess(MyClient, request, requestId).Status;
		}

		public string CallBack(string requestId)
		{
			return "STARTED";
		}
	}
}
