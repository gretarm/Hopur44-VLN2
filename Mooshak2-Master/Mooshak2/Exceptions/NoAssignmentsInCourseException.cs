using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Exceptions
{
	public class NoAssignmentsInCourseException : Exception
	{
		public NoAssignmentsInCourseException()
		{
		}

		public NoAssignmentsInCourseException(string message) : base(message)
		{
		}

		public NoAssignmentsInCourseException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}