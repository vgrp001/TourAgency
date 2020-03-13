using System.Collections.Generic;
using TourAgency.Bll.BusinessModels.ResponseModel;
using TourAgency.Bll.DTO;

namespace TourAgency.Bll.Services.Interfaces
{
    public interface IManagerService : ITourService
    {
        void UpdateTour(TourDTO model);
        void UpdateTourCustomer(TourCustomerDTO model);
        ListOptionModel GetListOption();
        void BlockCustomer(int id);
        void UnlockCustomer(int id);
        List<CustomerDTO> GetAllCustomers();
        CustomerDTO GetCustomerById(int id);
        void ChangeDiscountCustomer(CustomerDTO customerDto);
    }
}
