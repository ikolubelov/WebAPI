using BusinessLogic.Interfaces;
using Core;
using System;
using System.Net;
using RestSharp;
using Core.Models;
using Core.Enums;

namespace BusinessLogic.Service.Client
{
	public class MyClient : IMyClient, IDisposable
	{
		public readonly RestClient MyRestClient;

		public MyClient()
		{
			MyRestClient = new RestClient();
		}

		public MyClient(RestClient restClient)
		{
			MyRestClient = restClient;
		}


		public MyClientResponse CheckRequestStatus(MyClientRequest request)
		{
			var url = $"http://example.com/{request.RequestID}";
			var response = HandleMyClientRequest(url, request, Method.GET);

			return response.StatusCode == HttpStatusCode.OK ?
			new MyClientResponse(MyClientResponseTypes.Success)
			{
				RawResponse = response.Content,
				StatusCode = HttpStatusCode.OK,
			} :
			new MyClientResponse(MyClientResponseTypes.Error)
			{
				RawResponse = response.StatusDescription,
				StatusCode = response.StatusCode
			};
		}


		public MyClientResponse PostData(MyClientRequest request)
		{
			//in real scenario this will be retrieved from db
			var url = $"http://example.com";
			var response = HandleMyClientRequest(url, request, Method.POST);

			//since the reference url is not live - i hardcoded response to OK status 
			response.StatusCode = HttpStatusCode.OK;	

			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
					return new MyClientResponse(MyClientResponseTypes.Success)
					{
						StatusCode = HttpStatusCode.OK 
					};
				case HttpStatusCode.BadRequest:
					return new MyClientResponse(MyClientResponseTypes.BadRequest)
					{
						StatusCode = HttpStatusCode.BadRequest
					};
				default:
					return new MyClientResponse(MyClientResponseTypes.Error)
					{
						StatusCode = HttpStatusCode.InternalServerError
					};
			}
		}

		public IRestResponse HandleMyClientRequest(string url, MyClientRequest clRequest, Method method)
		{
			MyRestClient.BaseUrl = new Uri(url);

			var request = new RestRequest(method)
			{
				ReadWriteTimeout = 3600
			};

			//in real scenario we could add more parameters to Header (e.g. token authentication, accept)
			request.AddHeader("Content-Type", "application/json");

			if (method == Method.POST || method == Method.PUT)
			{
				request.AddParameter("application/json", clRequest.Body, ParameterType.RequestBody);
			}

			return MyRestClient.Execute(request);
		}

		public void Dispose()
		{
		}
	}
}