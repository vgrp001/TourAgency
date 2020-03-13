using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourAgency.Bll.DTO;
using TourAgency.Bll.Services.Interfaces;
using TourAgency.Web.Filters;
using TourAgency.Web.Helpers;
using TourAgency.Web.Models;
using TourAgency.Web.Models.Paginations;

namespace TourAgency.Web.Controllers
{
    [Authorize(Roles = "manager, admin")]
    public class ManagerController : Controller
    {
        // GET: Manager
        private readonly IManagerService _managerService;
        public ManagerController(IManagerService manager)
        {
            _managerService = manager;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult InfoTourSelect(int page = 1)
        {

            int pageSize = 3;
            var activeTours = _managerService.GetActiveTours();
            var activeToursViewModel = MappingViewModel.MapTourListViewModel(activeTours);

            var activeToursPerPages = activeToursViewModel.Skip((page - 1) * pageSize).Take(pageSize);

            var pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = activeToursViewModel.Count };
            var ivm = new TourPaginViewModel { PageInfo = pageInfo, Tours = activeToursPerPages };
            return View(ivm);
        }
        public ActionResult UpdateTour(int id, string startOfTour, string endOfTour,
            int? typeOfTourId, int? typeOfHotelsId, int? maxNumberOfPeople, int? price,
            int? cityId, string isHot, int? numberOfOrders)
        {
            if (Request.HttpMethod == "POST")
            {
                var tour = MappingViewModel.MapTourViewModel(_managerService.GetTourById(id));
                DateTime startOfTourDate = DateTime.MinValue;
                DateTime endOfTourDate = DateTime.MinValue;
                bool update = false;
                if (!string.IsNullOrEmpty(startOfTour) || !string.IsNullOrEmpty(endOfTour))
                {
                    startOfTourDate = Convert.ToDateTime(startOfTour);
                    endOfTourDate = Convert.ToDateTime(endOfTour);
                    if (startOfTourDate > endOfTourDate)
                        ModelState.AddModelError("date", "Enter valid dates");
                    else
                    {
                        tour.StartOfTour = startOfTourDate;
                        tour.StartOfTour = endOfTourDate;
                        update = true;
                    }
                }
                if (ModelState.IsValid)
                {
                    if (typeOfTourId != null)
                    {
                        tour.TypeOfTourId = typeOfTourId.Value;
                        update = true;
                    }
                    if (typeOfHotelsId != null)
                    {
                        tour.TypeOfHotelId = typeOfHotelsId.Value;
                        update = true;
                    }
                    if (maxNumberOfPeople != null)
                    {
                        tour.MaxNumberOfPeople = maxNumberOfPeople.Value;
                        update = true;
                    }
                    if (price != null)
                    {
                        tour.Price = price.Value;
                        update = true;
                    }
                    if (cityId != null)
                    {
                        tour.CityId = cityId.Value;
                        update = true;
                    }
                    if (numberOfOrders != null)
                    {
                        tour.NumberOfOrders = numberOfOrders.Value;
                        update = true;
                    }
                    bool isHotType = Convert.ToBoolean(isHot);
                    if (!((tour.IsHot && isHotType) ||
                        (!tour.IsHot && !isHotType)))
                    {
                        tour.IsHot = Convert.ToBoolean(isHot);
                        update = true;
                    }
                    if (update)
                    {
                        var updateTour = MappingViewModel.MapTourDTO(tour);
                        _managerService.UpdateTour(updateTour);
                        return View("Index");
                    }
                    else
                    {
                        ViewBag.ListOption = _managerService.GetListOption();
                        ModelState.AddModelError("Update", "Tour not updated");
                        return View(tour);
                    }
                }
                else
                {
                    ViewBag.ListOption = _managerService.GetListOption();
                    return View(tour);
                }
            }
            else
            {
                ViewBag.ListOption = _managerService.GetListOption();
                var tour = MappingViewModel.MapTourViewModel(_managerService.GetTourById(id));
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
        [NullException]
        public ActionResult UpdateStatus(List<int?> typeOfStatusId)
        {
            var registeredTours = _managerService.GetRegisteredTours();
            var registeredToursViewModel = MappingViewModel.MapTourCustomerListViewModel(registeredTours);
            if (Request.HttpMethod == "POST")
            {
                if (typeOfStatusId != null)
                {
                    for (int i = 0; i < typeOfStatusId.Count; i++)
                    {
                        if (typeOfStatusId[i] != null)
                        {
                            registeredToursViewModel[i].TypeOfStatusId = typeOfStatusId[i].Value;
                            var updateTour = MappingViewModel.MapTourCustomerDTO(registeredToursViewModel[i]);
                            _managerService.UpdateTourCustomer(updateTour);
                        }
                    }
                }
                return View("Index");
            }
            else
            {
                ViewBag.ListOption = _managerService.GetListOption();
                return View(registeredToursViewModel);
            }
        }
        public ActionResult UpdateCustomerInformation(int page = 1)
        {
            int pageSize = 6;
            var customers = _managerService.GetAllCustomers();
            var customersViewModel = MappingViewModel.MapCustomerListViewModel(customers);

            var customersPerPages = customersViewModel.Skip((page - 1) * pageSize).Take(pageSize);

            var pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = customersViewModel.Count };
            var ivm = new CustomerPaginViewModel { PageInfo = pageInfo, Customers = customersPerPages };
            return View(ivm);
        }
        public ActionResult ChangeDiscount(int id, int? maxDiscount,int? stepDiscount)
        {
            var customer = _managerService.GetCustomerById(id);
            var customerViewModel = MappingViewModel.MapCustomerViewModel(customer);
            if (Request.HttpMethod == "POST")
            {
                customer.StepDiscount = stepDiscount.Value;
                customer.MaxDiscount = maxDiscount.Value;

                _managerService.ChangeDiscountCustomer(customer);
                return View("Index");
            }
            else
            {
                return View(customerViewModel);
            }
        }
        protected override void Dispose(bool disposing)
        {
            _managerService.Dispose();
            base.Dispose(disposing);
        }
    }
}