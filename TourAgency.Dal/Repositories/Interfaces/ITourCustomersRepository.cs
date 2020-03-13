using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourAgency.Dal.Repositories.Interfaces
{
    public interface ITourCustomersRepository
    {
        void SetStatus(int id, int idStatus);
    }
}
