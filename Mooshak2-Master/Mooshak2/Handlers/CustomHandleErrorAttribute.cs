using Mooshak2.Exceptions;
using Mooshak2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.Handlers
{
	public class CustomHandleErrorAttribute : HandleErrorAttribute
	{
		public override void OnException(ExceptionContext filterContext)
		{
			Exception TheException = filterContext.Exception;
			Logger.Instance.LogException(TheException);

			string viewName = "";
			string CurrentController = (string)filterContext.RouteData.Values["controller"];
			string CurrentActionName = (string)filterContext.RouteData.Values["action"];

			if (TheException is NoStudentInCourseException)
			{
				viewName = "NoStudentError";
			}
			else if (TheException is NoAssignedCoursesException)
			{
				viewName = "NoAssignedCoursesError";
			}
			else if (TheException is NoCourseFoundException)
			{
				viewName = "NoCourseFoundError";
			}
			else if (TheException is NoTeacherInCourseException)
			{
				viewName = "NoCourseTeacherError";
			}
			else if (TheException is MissingIdException)
			{
				viewName = "MissingIdError";
			}
			else if(TheException is NoAssignmentsInCourseException)
			{
				viewName = "NoAssignmentInCourseError";
			}

			HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, CurrentController, CurrentActionName);
			ViewResult result = new ViewResult
			{
				ViewName = viewName,
				ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
				TempData = filterContext.Controller.TempData
			};

			filterContext.Result = result;
			filterContext.ExceptionHandled = true;

			base.OnException(filterContext);
		}
	}
}