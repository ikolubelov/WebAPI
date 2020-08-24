using BusinessLogic.Interfaces;
using Core.Enums;
using Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Implementations
{

	//this is client business object 
	//any business logic related to client before sending request should go here
	//this could be useful when there are other applications using the same client
	//This object is responsible for handling client response
	//client api response will be returned back to general business object
	public class MyClientBusinessLogic : IMyClientBusinessLogic
	{

		/// <summary>
		/// This method calls third-party service and sends request
		/// Client will process request within few days. This is why we are 
		/// just posting data and only check is to make sure that request submitted successfuly
		/// </summary>
		/// <param name="request">client details, request sent from front-end, request id</param>
		/// <returns>status of request</returns>
		public string StartPostingProcess(IMyClient myClient,
													MyRequest preDefinedRequest,
													string requestId)
		{
			string result = string.Empty;

			var request = new MyClientRequest()
			{
				Body = preDefinedRequest,
				CallBackUrl = $"api/MyTask/RequestReceived/{requestId}" //Since this is an exercise it is ok to have hard coded values 
			};

			//calling third party service
			//This method just posts data to the third party service
			//We want to make sure that post was successful. 
			//"PostData" method has a simple logic to check transaction status
			//the purpose of "response" class is to return status of http rerequest and based on status we can have logic to populate apiResponse which is json 
			var response = myClient.PostData(request);

			//process response
			if (response.ResponseType == MyClientResponseTypes.BadRequest || response.ResponseType == MyClientResponseTypes.Error)
			{
				//this is the part where we can have handle error class and take care of errors; we can log error and other details
				//for this exercise we are just returning string
				result = "HRTTP REQUEST ERROR";
			}
			else if (response.ResponseType == MyClientResponseTypes.Success)
			{
				//if we would have some additional logic this is the part where we can have handle success class
				result = "HRTTP REQUEST SUCCESS";
			}

			return result;
		}

		public async Task<MyClientAPIResponse> CheckRequestStatus(IMyClient myClient, string requestId)
		{
			//this is json response object
			MyClientAPIResponse model = null;

			var request = new MyClientRequest()
			{
				RequestID = requestId
			};


			//we can have a separate table for tracking purpose (Request, Response, RequestUrl, InsertedBy, UpdatedBy, InsertDate, UpdatedDate) 
			//before calling service we can log API end point details in to db
			//(since this is exercise table is not created)

			//calling client
			var response = await myClient.CheckRequestStatus(request);

			//after response is received we can update certain columns in the table 
			//(since this is exercise table is not created)
			
			//process response
			if (response.ResponseType == MyClientResponseTypes.BadRequest || response.ResponseType == MyClientResponseTypes.Error)
			{
				//this is the part where we can create error handler class and take care of errors
				//returning null back to business object would indicate that http request failed
				return null;
			}
			else if (response.ResponseType == MyClientResponseTypes.Success)
			{

				//since client's end point does not exist - i hardcoded json
				response.RawResponse = "{'Status': 'COMPLETED', 'Detail': 'This is my details', 'Body': 'This is responsebody', 'LastActionDate': '05/05/03' }";
				
				//getting data from response
				model = JsonConvert.DeserializeObject<MyClientAPIResponse>(response.RawResponse);
				
			}

			return model;
		}
	}
}
