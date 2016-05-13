using Mooshak2.Handlers;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
			//filters.Add(new HandleErrorAttribute());
			filters.Add(new CustomHandleErrorAttribute());
		}
    }
}
