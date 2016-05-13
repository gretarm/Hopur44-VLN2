using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Exceptions
{
	public class NoAssignedCoursesException : Exception
	{
		public NoAssignedCoursesException()
		{
		}

		public NoAssignedCoursesException(string message) : base(message)
		{
		}

		public NoAssignedCoursesException(string message, Exception inner) : base(message, inner)
		{
		}

	}
}