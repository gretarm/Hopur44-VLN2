using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Exceptions
{
	public class NoCourseFoundException : Exception
	{
		public NoCourseFoundException()
		{
		}

		public NoCourseFoundException(string message) : base(message)
		{
		}

		public NoCourseFoundException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}