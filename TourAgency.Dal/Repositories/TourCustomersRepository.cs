using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency.Dal.EF;
using TourAgency.Dal.Entities;
using TourAgency.Dal.Repositories.Interfaces;

namespace TourAgency.Dal.Repositories
{
    public class TourCustomersRepository : BaseRepository<TourCustomer>, ITourCustomersRepository
    {
        public TourCustomersRepository(TourAgencyContext context) : base(context)
        {
        }
        public void SetStatus(int id, int idStatus)
        {
            TourCustomer tourCustomer = tourAgencyContext.TourCustomers.Find(id);
            TypeOfStatus typeOfStatus = tourAgencyContext.TypeOfStatuses.Where(u => u.Id == idStatus).FirstOrDefault();
            tourCustomer.TypeOfStatus = typeOfStatus;
            tourCustomer.TypeOfStatusId = typeOfStatus.Id;
            Update(tourCustomer);
        }
    }
}
