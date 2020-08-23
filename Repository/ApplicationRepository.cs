using Core.Enums;
using Core.Models;
using Data;
using System;
using System.Linq;

namespace Repository
{
	public class ApplicationRepository
	{
		private readonly ApplicationContext ctx;

		public ApplicationRepository(ApplicationContext _ctx)
		{
			ctx = _ctx;
		}

		public virtual MyAppRequest GetMyRequest(string requestId)
		{
			return ctx.MyAppRequest.FirstOrDefault(x => x.RequestId == requestId);
		}

		/// <summary>
		/// Saves/updates request details.
		/// </summary>
		/// <param name="model">MyApp Request</param>
		/// <param name="requestId">request identifier.</param>
		public void SaveUpdateMyRequest(MyAppRequest model)
		{
			var request = GetMyRequest(model.RequestId);

			if(request == null)
			{
				model.InsertedBy = "abcd"; //user id or lanid will be sent from controller all the way to the repository
				model.InsertDate = DateTime.UtcNow;
				model.UpdatedBy = "abcd";
				model.UpdatedDate = DateTime.UtcNow;

				ctx.MyAppRequest.Add(model);
			}
			else
			{
				request.Status = model.Status; //we can have enum for statuses and save ID
				request.Details = model.Details;
				request.UpdatedBy = "abcd";
				request.UpdatedDate = DateTime.UtcNow;
			}

			ctx.SaveChanges();
		}

		/// <summary>
		/// Saves/updates request details.
		/// </summary>
		/// <param name="model">MyApp Request</param>
		/// <param name="requestId">request identifier.</param>
		public void SaveUpdateMyRequest(string status, string requestId)
		{
			var request = GetMyRequest(requestId);
			request.Status = status;

			SaveUpdateMyRequest(request);
		}
	}
}
