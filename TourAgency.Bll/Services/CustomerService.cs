using System;
using System.Threading.Tasks;
using System.Linq;
using TourAgency.Bll.DTO;
using TourAgency.Bll.Helpers;
using TourAgency.Bll.Services.Interfaces;
using TourAgency.Dal.Entities;
using TourAgency.Dal.UnitOfWork.Interfaces;
using System.Collections.Generic;

namespace TourAgency.Bll.Services
{
    public class CustomerService : TourService, ICustomerService
    {
        private readonly IUnitOfWork _dataBase;
        public CustomerService(IUnitOfWork dataBase) : base(dataBase)
        {
            _dataBase = dataBase;
        }
        public List<TourCustomerDTO> GetTourCustomerByCustomerId(string userId)
        {
            var tourCustomer = _dataBase.TourCustomers.GetAll();
            var customerId = _dataBase.Customers.GetCustomerIdByIdentityUserId(userId);
            var customerTour = tourCustomer.Where(u => u.CustomerId == customerId);
            var tourDto = MappingDTO.MapTourCustomerListDTO(customerTour.ToList());
            return tourDto;
        }

        public void Register(CustomerDTO model)
        {
            var customer = MappingDTO.MapCustomer(model);
            _dataBase.Customers.Register(customer);
            _dataBase.Save();
        }

        public void BuyTour(TourDTO tourDto, string userId, int realNumberOfPeople, int realPrice)
        {
            var customerId = _dataBase.Customers.GetCustomerIdByIdentityUserId(userId);
            var typeOfStatusRegistered = _dataBase.TypeOfStatuses.Get("Registered");
            var tourCustomer = new TourCustomer()
            {
                TourId = tourDto.Id,
                CustomerId = customerId,
                TypeOfStatusId = typeOfStatusRegistered.Id,
                RealNumberOfPeople = realNumberOfPeople,
                RealPrice = realPrice
            };
            var tour = MappingDTO.MapTour(tourDto);
            tour.NumberOfOrders--;
            _dataBase.Tours.UpdateInfo(tour);
            _dataBase.TourCustomers.Create(tourCustomer);
            _dataBase.Save();
        }

        public CustomerDTO GetCustomerByIdentityUserId(string userId)
        {
            var customerId = _dataBase.Customers.GetCustomerIdByIdentityUserId(userId);
            if(customerId == -1)
                return null;
            var customer =  _dataBase.Customers.Get(customerId);
            var customerDto = MappingDTO.MapCustomerDTO(customer);
            return customerDto;
        }

        public void ChangePersonalInformation(CustomerDTO customerDto)
        {
            var customer = _dataBase.Customers.Get(customerDto.Id);
            if (customer != null)
            {
                customer.Name = customerDto.Name;
                customer.Surname = customerDto.Surname;
                _dataBase.Customers.Update(customer);
            }
            _dataBase.Save();
        }
    }
}
