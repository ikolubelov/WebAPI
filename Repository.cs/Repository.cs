using Data;
using System;

namespace Repository
{
	public class Repository
	{
		private readonly ApplicationContext _ctx;
		
		public Repository(ApplicationContext ctx)
		{
			_ctx = ctx;
		}
	}
}
