using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourAgency.Bll.DTO;
using TourAgency.Bll.Services.Interfaces;
using TourAgency.Web.Helpers;
using TourAgency.Web.Models;

namespace TourAgency.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ITourService _tourService;
        private readonly ICustomerService _customerService;

        public HomeController(ITourService tour, ICustomerService customer)
        {
            _tourService = tour;
            _customerService = customer;
        }
        public ActionResult Index()
        {
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
            var tours = MappingViewModel.MapTourListViewModel(_tourService.GetHotAndNewTours());
            return View(tours);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            _tourService.Dispose();
            base.Dispose(disposing);
        }
    }
}