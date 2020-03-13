using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourAgency.Bll.Services.Interfaces;
using TourAgency.Web.Helpers;
using TourAgency.Web.Models;

namespace TourAgency.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService administrator)
        {
            _adminService = administrator;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateNewTour(string startOfTour, string endOfTour,
    int? typeOfTourId, int? typeOfHotelsId, int? maxNumberOfPeople, int? price, int? cityId, int? numberOfOrders)
        {
            if (Request.HttpMethod == "POST")
            {
                DateTime startOfTourDate = DateTime.MinValue;
                DateTime endOfTourDate = DateTime.MinValue;
                if (string.IsNullOrEmpty(startOfTour) || string.IsNullOrEmpty(endOfTour))
                    ModelState.AddModelError("date", "Enter valid dates");
                else
                {
                    startOfTourDate = Convert.ToDateTime(startOfTour);
                    endOfTourDate = Convert.ToDateTime(endOfTour);
                    if (startOfTourDate > endOfTourDate)
                        ModelState.AddModelError("date", "Enter valid dates");
                }
                if (typeOfTourId == null)
                    ModelState.AddModelError("typeOfTourId", "Please enter type of tour");
                if (typeOfHotelsId == null)
                    ModelState.AddModelError("typeOfHotelsId", "Please enter type of hotel");
                if (maxNumberOfPeople == null)
                    ModelState.AddModelError("maxNumberOfPeople", "Please enter max number of people");
                if (price == null)
                    ModelState.AddModelError("price", "Please enter price");
                if (cityId == null)
                    ModelState.AddModelError("cityId", "Please enter a city");
                if (numberOfOrders == null)
                    ModelState.AddModelError("typeOfTourId", "Please enter number of orders");
                if (ModelState.IsValid)
                {
                    var newTour = new TourViewModel()
                    {
                        StartOfTour = startOfTourDate,
                        EndOfTour = endOfTourDate,
                        TypeOfHotelId = typeOfHotelsId.Value,
                        TypeOfTourId = typeOfTourId.Value,
                        MaxNumberOfPeople = maxNumberOfPeople.Value,
                        IsDelete = false,
                        NumberOfOrders = numberOfOrders.Value,
                        Price = price.Value,
                        CityId = cityId.Value,
                        IsHot = false,
                    };
                    var newTourDTO = MappingViewModel.MapTourDTO(newTour);
                    _adminService.CreateTour(newTourDTO);
                    return RedirectToAction("/Index");
                }
                else
                {
                    var listOption = _adminService.GetListOption();
                    return View(listOption);
                }
            }
            else
            {
                var listOption = _adminService.GetListOption();
                return View(listOption);
            }
        }
        public ActionResult DeleteTour(int id)
        {
            if (Request.HttpMethod == "POST")
            {
                _adminService.DeleteTour(id);
                return View("Index");
            }
            else
            {
                var tour = MappingViewModel.MapTourViewModel(_adminService.GetTourById(id));
                if (tour == null)
                {
                    return HttpNotFound();
                }
                if (tour.NumberOfOrders <= 0)
                {
                    return HttpNotFound();
                }
                return View(tour);
            }
        }
        public ActionResult BlockUnlockCustomer(int? id)
        {
            if (id != null)
            {
                var customer = _adminService.GetCustomerById(id.Value);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                if (customer.IsBlock)
                {
                    _adminService.UnlockCustomer(id.Value);
                }
                else
                {
                    _adminService.BlockCustomer(id.Value);
                }
                return RedirectToAction("/Index");
            }
            var customers = _adminService.GetAllCustomers();
            var customersViewModel = MappingViewModel.MapCustomerListViewModel(customers);
            return View(customersViewModel);
        }
        public ActionResult BlockUnlockManager(int? id)
        {
            var managers = _adminService.GetAllManagers();
            var managersViewModel = MappingViewModel.MapManagerListViewModel(managers);
            if (Request.HttpMethod == "POST")
            {
                if (id != null)
                {
                    var manager = _adminService.GetManagerById(id.Value);
                    if (manager == null)
                    {
                        return HttpNotFound();
                    }
                    if (manager.IsBlock)
                    {
                        _adminService.UnlockManager(id.Value);
                    }
                    else
                    {
                        _adminService.BlockManager(id.Value);
                    }
                    return RedirectToAction("/Index");
                }
                return View(managersViewModel);
            }
            else
            {
                return View(managersViewModel);
            }
        }
        protected override void Dispose(bool disposing)
        {
            _adminService.Dispose();
            base.Dispose(disposing);
        }
    }
}