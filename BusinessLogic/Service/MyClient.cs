using BusinessLogic.Interfaces;
using Core;
using System;
using System.Net;
using RestSharp;
using Core.Models;
using Core.Enums;
using System.Threading.Tasks;
using System.Net.Http;

namespace BusinessLogic.Service.Client
{
	public class MyClient : IMyClient, IDisposable
	{
		public async Task<MyClientResponse> CheckRequestStatus(MyClientRequest request)
		{
			var url = $"http://example.com/{request.RequestID}";
			var client = new HttpClient();

			var response = await client.GetAsync(url);

			//since the reference url is not live - i hardcoded response to OK status 
			response.StatusCode = HttpStatusCode.OK;

			return response.IsSuccessStatusCode ?
			new MyClientResponse(MyClientResponseTypes.Success)
			{
				RawResponse = await response.Content.ReadAsStringAsync(),
				StatusCode = HttpStatusCode.OK,
			} :
			new MyClientResponse(MyClientResponseTypes.Error)
			{
				RawResponse = string.Empty,
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
			var MyRestClient = new RestClient();
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