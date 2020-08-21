using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using BusinessLogic.Implementations;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MyTaskController : ControllerBase
	{
		private readonly IMyTaskBusinessLogic BusinessLogic;

		public MyTaskController(IMyTaskBusinessLogic businessLogic)
		{
			BusinessLogic = businessLogic;
		}

		/// <summary>
		/// This method sends data to third party service
		/// </summary>
		/// <param name="request">payload details</param>
		/// <returns>status of request</returns>
		[HttpPost]
		public string PostData(Request request)
		{
			return BusinessLogic.PostData(request);
		}

		/// <summary>
		/// This method will be called by third-party service to notify 
		/// that request successfuly received and work started
		/// </summary>
		/// <param name="requestId">Identifier for which process started</param>
		/// <returns>status of request</returns>
		[HttpPost("CallBack/{requestId}")]
		public string ProcessCallBack(string requestId)
		{
			return BusinessLogic.ProcessCallBack(requestId);
		}
	}
}
