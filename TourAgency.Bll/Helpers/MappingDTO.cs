using AutoMapper;
using System;
using System.Collections.Generic;
using TourAgency.Bll.DTO;
using TourAgency.Dal.Entities;

namespace TourAgency.Bll.Helpers
{
    public static class MappingDTO
    {
        public static CustomerDTO MapCustomerDTO(Customer customer)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<TourCustomer, TourCustomerDTO>();
                cfg.CreateMap<Tour, TourDTO>()
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(src => src.Customers));
                cfg.CreateMap<City, CityDTO>();
                cfg.CreateMap<TypeOfHotel, TypeOfHotelDTO>();
                cfg.CreateMap<TypeOfStatus, TypeOfStatusDTO>();
                cfg.CreateMap<TypeOfTour, TypeOfTourDTO>();
            });
            var mapper = configuration.CreateMapper();
            var customerDTO = mapper.Map<Customer, CustomerDTO>(customer);
            return customerDTO;
        }

        public static Manager MapManager(ManagerDTO managerDTO)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ManagerDTO, Manager>()
                .ForMember(dest => dest.User, opt => opt.Ignore());
            });
            var mapper = configuration.CreateMapper();
            var manager = mapper.Map<ManagerDTO, Manager>(managerDTO);
            return manager;
        }
        public static ManagerDTO MapManagerDTO(Manager manager)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ManagerDTO, Manager>()
                .ForMember(dest => dest.User, opt => opt.Ignore());
            });
            var mapper = configuration.CreateMapper();
            var managerDto = mapper.Map<Manager, ManagerDTO>(manager);
            return managerDto;
        }

        public static List<ManagerDTO> MapManagerListDTO(List<Manager> managers)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Manager, ManagerDTO>()
                .ForMember(dest => dest.User, opt => opt.Ignore());
            });
            var mapper = configuration.CreateMapper();
            var managersDto = mapper.Map<List<Manager>, List<ManagerDTO>>(managers);
            return managersDto;
        }



        public static List<CustomerDTO> MapCustomerListDTO(List<Customer> customers)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<TourCustomer, TourCustomerDTO>();
                cfg.CreateMap<Tour, TourDTO>()
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(src => src.Customers));
                cfg.CreateMap<City, CityDTO>();
                cfg.CreateMap<TypeOfHotel, TypeOfHotelDTO>();
                cfg.CreateMap<TypeOfStatus, TypeOfStatusDTO>();
                cfg.CreateMap<TypeOfTour, TypeOfTourDTO>();
            });
            var mapper = configuration.CreateMapper();
            var customersDTO = mapper.Map<List<Customer>, List<CustomerDTO>>(customers);
            return customersDTO;
        }



        public static Customer MapCustomer(CustomerDTO customerDto)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<CustomerDTO, Customer>();
                cfg.CreateMap<TourCustomerDTO, TourCustomer>();
                cfg.CreateMap<TourDTO, Tour>()
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(src => src.Customers));
                cfg.CreateMap<CityDTO, City>();
                cfg.CreateMap<TypeOfHotelDTO, TypeOfHotel>();
                cfg.CreateMap<TypeOfStatusDTO, TypeOfStatus>();
                cfg.CreateMap<TypeOfTourDTO, TypeOfTour>();
            });
            var mapper = configuration.CreateMapper();
            var customer = mapper.Map<CustomerDTO, Customer>(customerDto);

            return customer;
        }

        public static TourDTO MapTourDTO(Tour tour)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<Tour, TourDTO>()
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(src => src.Customers));
                cfg.CreateMap<City, CityDTO>();
                cfg.CreateMap<TypeOfHotel, TypeOfHotelDTO>();
                cfg.CreateMap<TypeOfStatus, TypeOfStatusDTO>();
                cfg.CreateMap<TypeOfTour, TypeOfTourDTO>();
                cfg.CreateMap<TourCustomer, TourCustomerDTO>();
                cfg.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = configuration.CreateMapper();
            var tourDto = mapper.Map<Tour, TourDTO>(tour);
            return tourDto;
        }

        public static TourCustomerDTO MapTourCustomerDTO(TourCustomer tourCustomer)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<Tour, TourDTO>()
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(src => src.Customers));
                cfg.CreateMap<City, CityDTO>();
                cfg.CreateMap<TypeOfHotel, TypeOfHotelDTO>();
                cfg.CreateMap<TypeOfStatus, TypeOfStatusDTO>();
                cfg.CreateMap<TypeOfTour, TypeOfTourDTO>();
                cfg.CreateMap<TourCustomer, TourCustomerDTO>();
                cfg.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = configuration.CreateMapper();
            var tourCustomerDto = mapper.Map<TourCustomer, TourCustomerDTO>(tourCustomer);
            return tourCustomerDto;
        }
        public static List<TourDTO> MapTourListDTO(List<Tour> tour)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<Tour, TourDTO>()
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(src => src.Customers));
                cfg.CreateMap<City, CityDTO>();
                cfg.CreateMap<TypeOfHotel, TypeOfHotelDTO>();
                cfg.CreateMap<TypeOfStatus, TypeOfStatusDTO>();
                cfg.CreateMap<TypeOfTour, TypeOfTourDTO>();
                cfg.CreateMap<TourCustomer, TourCustomerDTO>();
                cfg.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = configuration.CreateMapper();
            var tourDto = mapper.Map<List<Tour>, List<TourDTO>>(tour);
            return tourDto;
        }

        public static List<TourCustomerDTO> MapTourCustomerListDTO(List<TourCustomer> tourCustomer)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<Tour, TourDTO>()
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(src => src.Customers));
                cfg.CreateMap<City, CityDTO>();
                cfg.CreateMap<TypeOfHotel, TypeOfHotelDTO>();
                cfg.CreateMap<TypeOfStatus, TypeOfStatusDTO>();
                cfg.CreateMap<TypeOfTour, TypeOfTourDTO>();
                cfg.CreateMap<TourCustomer, TourCustomerDTO>();
                cfg.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = configuration.CreateMapper();
            var tourCustomerDto = mapper.Map<List<TourCustomer>, List<TourCustomerDTO>>(tourCustomer);
            return tourCustomerDto;
        }
        public static Tour MapTour(TourDTO tourDto)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<TourDTO, Tour>()
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(src => src.Customers));
                cfg.CreateMap<CityDTO, City>();
                cfg.CreateMap<TypeOfHotelDTO, TypeOfHotel>();
                cfg.CreateMap<TypeOfStatusDTO, TypeOfStatus>();
                cfg.CreateMap<TypeOfTourDTO, TypeOfTour>();
                cfg.CreateMap<TourCustomerDTO, TourCustomer>();
                cfg.CreateMap<CustomerDTO, Customer>();
            });
            var mapper = configuration.CreateMapper();
            var tour = mapper.Map<TourDTO, Tour>(tourDto);
            return tour;
        }

        public static TourCustomer MapTourCustomer(TourCustomerDTO tourCustomerDto)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<TourDTO, Tour>()
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(src => src.Customers));
                cfg.CreateMap<CityDTO, City>();
                cfg.CreateMap<TypeOfHotelDTO, TypeOfHotel>();
                cfg.CreateMap<TypeOfStatusDTO, TypeOfStatus>();
                cfg.CreateMap<TypeOfTourDTO, TypeOfTour>();
                cfg.CreateMap<TourCustomerDTO, TourCustomer>();
                cfg.CreateMap<CustomerDTO, Customer>();
            });
            var mapper = configuration.CreateMapper();
            var tourCustomer = mapper.Map<TourCustomerDTO, TourCustomer>(tourCustomerDto);
            return tourCustomer;
        }
        public static TypeOfStatusDTO MapTypeOfStatusDTO(TypeOfStatus typeOfStatus)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TypeOfStatus, TypeOfStatusDTO>());
            var mapper = new Mapper(config);
            var typeOfStatusDto = mapper.Map<TypeOfStatusDTO>(typeOfStatus);
            return typeOfStatusDto;
        }
    }
}
