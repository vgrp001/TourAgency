using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourAgency.Bll.BusinessModels;
using TourAgency.Bll.Services.Interfaces;
using TourAgency.Web.Helpers;
using TourAgency.Web.Models;

namespace TourAgency.Web.Controllers
{
    [Authorize(Roles = "customer")]
    public class CustomerController : Controller
    {
        // GET: Customer
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public ActionResult Index()
        {
            var hotTours = _customerService.GetHotAndNewTours();
            var hotToursViewModel = MappingViewModel.MapTourListViewModel(hotTours);
            return View(hotToursViewModel);
        }
        public ActionResult TourСatalog(int? sort, int? sortType)
        {
            var activeTours = _customerService.GetActiveTours();
            var activeToursViewModel = MappingViewModel.MapTourListViewModel(activeTours);
            if (Request.HttpMethod == "POST")
            {
                if (sort != null && sortType != null)
                {
                    switch (sort.Value)
                    {
                        case 1:
                            {
                                if (sortType.Value == 2)
                                    activeToursViewModel.Sort((x, y) => x.Price.CompareTo(y.Price));
                                else
                                    activeToursViewModel.Sort((x, y) => y.Price.CompareTo(x.Price));
                                break;
                            }
                        case 2:
                            {
                                if (sortType.Value == 2)
                                    activeToursViewModel.Sort((x, y) => x.TypeOfTourId.CompareTo(y.TypeOfTourId));
                                else
                                    activeToursViewModel.Sort((x, y) => y.TypeOfTourId.CompareTo(x.TypeOfTourId));
                                break;
                            }
                        case 3:
                            {
                                if (sortType.Value == 2)
                                    activeToursViewModel.Sort((x, y) => x.MaxNumberOfPeople.CompareTo(y.MaxNumberOfPeople));
                                else
                                    activeToursViewModel.Sort((x, y) => y.MaxNumberOfPeople.CompareTo(x.MaxNumberOfPeople));
                                break;
                            }
                        case 4:
                            {
                                if (sortType.Value == 2)
                                    activeToursViewModel.Sort((x, y) => x.TypeOfHotel.NumberOfStars.CompareTo(y.TypeOfHotel.NumberOfStars));
                                else
                                    activeToursViewModel.Sort((x, y) => y.TypeOfHotel.NumberOfStars.CompareTo(x.TypeOfHotel.NumberOfStars));
                                break;
                            }
                        case 5:
                            {
                                if (sortType.Value == 2)
                                    activeToursViewModel.Sort((x, y) => x.StartOfTour.CompareTo(y.StartOfTour));
                                else
                                    activeToursViewModel.Sort((x, y) => y.StartOfTour.CompareTo(x.StartOfTour));
                                break;
                            }
                        default:
                            break;
                    }
                }
                return View(activeToursViewModel);
            }
            else
            {
                return View(activeToursViewModel);
            }
        }
        public ActionResult OrderTour(int id, int? realNumberOfPeople)
        {
            var tour = _customerService.GetTourById(id);
            var tourViewModel = MappingViewModel.MapTourViewModel(tour);
            var userId = User.Identity.GetUserId();
            var customer = _customerService.GetCustomerByIdentityUserId(userId);
            if (Request.HttpMethod == "POST")
            {
                var tourDto = MappingViewModel.MapTourDTO(tourViewModel);
                _customerService.BuyTour(tourDto, userId, realNumberOfPeople.Value, Discount.DiscountPrice(tourViewModel.Price, customer.Discount));
                return RedirectToAction("/Index");
            }
            else
            {
                ViewBag.PriceForCustomer = Discount.DiscountPrice(tourViewModel.Price, customer.Discount);
                return View(tourViewModel);
            }
        }
        public ActionResult ListMyTours()
        {
            var userId = User.Identity.GetUserId();
            var tours = _customerService.GetTourCustomerByCustomerId(userId);
            var toursViewModel = MappingViewModel.MapTourCustomerListViewModel(tours);
            return View(toursViewModel);
        }
        public ActionResult PersonalArea()
        {
            var userId = User.Identity.GetUserId();
            var tours = _customerService.GetTourCustomerByCustomerId(userId);
            var customer = _customerService.GetCustomerByIdentityUserId(userId);
            var cistomerViewModel = MappingViewModel.MapCustomerViewModel(customer);
            var toursViewModel = MappingViewModel.MapTourCustomerListViewModel(tours);
            ViewBag.Customer = cistomerViewModel;
            return View(toursViewModel);
        }

        public ActionResult ChangeInformation(string name, string surname)
        {
            var userId = User.Identity.GetUserId();
            var customer = _customerService.GetCustomerByIdentityUserId(userId);
            var cistomerViewModel = MappingViewModel.MapCustomerViewModel(customer);
            if (Request.HttpMethod == "POST")
            {
                if (name.Length <= 3)
                    ModelState.AddModelError("name", "Please enter valid name");
                if (surname.Length <= 3)
                    ModelState.AddModelError("surname", "Please enter valid surname");
                if (ModelState.IsValid)
                {
                    customer.Name = name;
                    customer.Surname = surname;
                    _customerService.ChangePersonalInformation(customer);
                    return RedirectToAction("/PersonalArea");
                }
                else
                {
                    return View(cistomerViewModel);
                }
            }
            else
            {
                return View(cistomerViewModel);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _customerService.Dispose();
            base.Dispose(disposing);
        }
    }
}