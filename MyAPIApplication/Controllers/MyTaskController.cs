using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using BusinessLogic.Implementations;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
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
		public string Post([FromBody] Request request)
		{
			return BusinessLogic.PostData (request);
		}

		/// <summary>
		/// This is callback method used by third-party service to notify 
		/// that request successfuly received and work started
		/// </summary>
		/// <param name="requestId">Identifier for which process started</param>
		/// <param name="requestStatus">status of request</param>
		/// <returns>status of request</returns>
		[HttpPost("RequestReceived/{requestId}/{requestStatus}")]
		public IActionResult Post(string requestId, string requestStatus)
		{
			BusinessLogic.ProcessCallBack(requestId, requestStatus);

			return NoContent();
		}

		/// <summary>
		/// This is callback method used by third-party service to send 
		/// status update for a given request
		/// </summary>
		/// <param name="requestId">Identifier for which process started</param>
		/// <param name="myClientResponse">client response</param>
		/// <returns>status of request</returns>
		[HttpPut("UpdateRequestStatus/{requestId}")]
		public IActionResult UpdateRequest(string requestId, [FromBody] MyClientResponse myClientResponse)
		{
			BusinessLogic.UpdateRequestStatus(requestId, myClientResponse);

			return NoContent();
		}


		/// <summary>
		/// This method will get sattus from third-party service
		/// for a given request ID
		/// </summary>
		/// <param name="requestId">unique reuest Identifier</param>
		/// <returns>status of request</returns>
		[HttpGet("CheckStatus/{requestId}")]
		public MyClientResponse Get(string requestId)
		{
			return BusinessLogic.CheckRequestStatus(requestId);
		}
	}
}
