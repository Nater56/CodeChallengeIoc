using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheIocProject.Services
{
	public class CountingService : ICountingService
	{
		private int _i = 0;

		public int GetNumber()
		{
			return _i++;
		}
	}
}