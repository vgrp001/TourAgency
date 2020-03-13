using System;
using TourAgency.Dal.EF;
using TourAgency.Dal.Entities;
using TourAgency.Dal.Repositories.Interfaces;

namespace TourAgency.Dal.Repositories
{
    public class ManagerRepository : BaseRepository<Manager>, IManagerRepository
    {
        public ManagerRepository(TourAgencyContext context) : base(context)
        {
        }

        public void Register(Manager manager)
        {
            tourAgencyContext.Managers.Add(manager);
        }
    }
}
