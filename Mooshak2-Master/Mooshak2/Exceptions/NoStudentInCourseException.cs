using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Exceptions
{
	public class NoStudentInCourseException : Exception
	{
		public NoStudentInCourseException()
		{
		}

		public NoStudentInCourseException(string message) : base(message)
		{
		}

		public NoStudentInCourseException(string message, Exception inner) : base(message, inner)
		{
		}

	}
}