using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Exceptions
{
	public class MissingIdException : Exception
	{
		public MissingIdException()
		{
		}

		public MissingIdException(string message) : base(message)
		{
		}

		public MissingIdException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}