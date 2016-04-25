using System.Web;
using System.Web.Mvc;

namespace Vattenfall_IT_test
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
