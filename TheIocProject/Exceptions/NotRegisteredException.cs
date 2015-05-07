using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheIocProject.Exceptions
{
	public class NotRegisteredException : System.Exception
	{
		NotRegisteredException()
		{
			
		}

		public NotRegisteredException(string message) : base(message)
		{
			
		}

		public NotRegisteredException(string message, Exception innerException) :base(message, innerException)
		{
			
		}
	}
}