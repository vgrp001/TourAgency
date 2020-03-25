using Serilog;
using System.Web.Hosting;
using System.Web.Mvc;
using TourAgency.Bll.Services.Interfaces;
using TourAgency.Web.Helpers;

namespace TourAgency.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITourService _tourService;
        public HomeController(ITourService tourService)
        {
            _tourService = tourService;
        }
        public ActionResult Index()
        {
            _tourService.GetActiveTours();
            if (User.IsInRole("admin"))
            {
                return RedirectPermanent("/Admin/Index");
            }
            else if (User.IsInRole("manager"))
            {
                return RedirectPermanent("/Manager/Index");
            }
            else if (User.IsInRole("customer"))
            {
                return RedirectPermanent("/Customer/Index");
            }
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            _tourService.Dispose();
            base.Dispose(disposing);
        }
    }
}