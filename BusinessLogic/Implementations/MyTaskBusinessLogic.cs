using System;
using System.Net;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Core.Enums;
using Core.Mapping;
using Core.Models;
using Data;
using Repository;

namespace BusinessLogic.Implementations
{
	//This class is intended to handle some business logic before calling Client
	//This might be an overkill for this exercise.
	//But the goal is to minimize any business logic in controller and have it in a separate tier.
	public class MyTaskBusinessLogic : IMyTaskBusinessLogic
	{
		private readonly IMyClient MyClient;
		private readonly IMyClientBusinessLogic MyClientBusinessLogic;

		//ideally we should have interface created for Application Context and ApplicationRepository 
		private readonly ApplicationRepository Repository;

		public MyTaskBusinessLogic(IMyClient myClient, IMyClientBusinessLogic myClientBusinessLogic, ApplicationRepository repository)
		{
			MyClient = myClient;
			MyClientBusinessLogic = myClientBusinessLogic;
			Repository = repository;
		}

		/// <summary>
		/// This method posts data sent from front-end to client
		/// </summary>
		/// <param name="request">payload details</param>
		/// <returns>status of request</returns>
		public string PostData(MyRequest request)
		{
			//generate unique id
			var requestId = Guid.NewGuid().ToString();

			//call client to post data (having client object might be overkill for this exercise but in real app it would be recommended)
			var status = MyClientBusinessLogic.StartPostingProcess(MyClient, request, requestId);

			//saving request details in db
			Repository.SaveUpdateMyRequest(request.ToDBRequestModel(requestId, status));

			//returning result back to caller 
			return status ;
		}

		/// <summary>
		/// This method is called by third-party service to
		/// notify that process started
		/// </summary>
		/// <param name="requestId">unique identifier for request</param>
		/// <returns>status of request</returns>
		public void ProcessCallBack(string requestId, string status)
		{

			var request = Repository.GetMyRequest(requestId);

			if (request == null)
			{
				//log error here and return null back to the caller
				return;
			}

			//call repository to update status
			request.Status = status;
			Repository.SaveUpdateMyRequest(request);
		}

		/// <summary>
		/// This method updates details for a given request
		/// </summary>
		/// <param name="requestId">unique identifier for request</param>
		/// <param name="myClientAPIResponse">requestDetails</param>
		/// <returns>response object</returns>
		public void UpdateRequestStatus(string requestId, MyClientAPIResponse myClientAPIResponse)
		{
			//here we can check of this is valid request and if it exists in db
			var request = Repository.GetMyRequest(requestId);

			if (request == null)
			{
				//log and throw error here
				return;
			}

			Repository.SaveUpdateMyRequest(myClientAPIResponse.ToDBRequestModel(requestId));
		}
		
		/// <summary>
		/// This method calls third-party service to check status of request
		/// </summary>
		/// <param name="requestId">unique identifier for request</param>
		/// <returns>client response object</returns>
		public async Task<MyClientAPIResponse> CheckRequestStatus(string requestId)
		{
			//here we can check of this is valid request and if it exists in db
			var request = Repository.GetMyRequest(requestId);

			if (request == null)
			{
				//log error here and return null back to the caller
				return null;
			}

			//get status from client
			var response =  await MyClientBusinessLogic.CheckRequestStatus(MyClient, requestId);

			if (response == null)
			{
				//log error here and return null back to the caller
				return null;
			}

			//update request status
			Repository.SaveUpdateMyRequest(response.ToDBRequestModel(requestId));

			return response;

		}
	}
}
