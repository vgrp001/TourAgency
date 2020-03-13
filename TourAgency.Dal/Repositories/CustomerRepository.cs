using System.Linq;
using TourAgency.Dal.EF;
using TourAgency.Dal.Entities;
using TourAgency.Dal.Repositories.Interfaces;

namespace TourAgency.Dal.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(TourAgencyContext context) : base(context)
        {
        }
        public int GetCustomerIdByIdentityUserId(string userId)
        {
            var customer = tourAgencyContext.Customers.Where(u => u.UserId == userId).FirstOrDefault();
            if(customer is null)
                return -1;
            return customer.Id;
        }
        public void Register(Customer customer)
        {
            tourAgencyContext.Customers.Add(customer);
        }
    }
}
