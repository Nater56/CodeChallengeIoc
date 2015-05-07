using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheIocProject.Container
{
	public class RegisteredObject
	{
		public RegisteredObject(Type from, Type to, bool isTransient)
		{
			From = from;
			To = to;
			IsTransient = isTransient;
		}

		public Type From { get; set; }

		public Type To { get; set; }

        public object Instance { get; set; }

        public bool IsTransient { get; set; }

		public void CreateInstance(params object[] args)
		{
			this.Instance = Activator.CreateInstance(this.To, args);
		}
	}
}
