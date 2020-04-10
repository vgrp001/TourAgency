using System.Web.Mvc;
using TourAgency.Web.Filters;

namespace TourAgency.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new NullExceptionFilter());
            filters.Add(new ValidationExceptionFilter());
        }
    }
}
