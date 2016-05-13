using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Exceptions
{
	public class NoTeacherInCourseException : Exception
	{
		public NoTeacherInCourseException()
		{
		}

		public NoTeacherInCourseException(string message) : base(message)
		{
		}

		public NoTeacherInCourseException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}