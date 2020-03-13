using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency.Bll.DTO;

namespace TourAgency.Bll.BusinessModels.ResponseModel
{
    public class ListOptionModel
    {
        public List<CityDTO> Cities { get; set; }
        public List<TypeOfHotelDTO> TypeOfHotels { get; set; }
        public List<TypeOfTourDTO> TypeOfTours { get; set; }
        public List<TypeOfStatusDTO> TypeOfStatuses { get; set; }
    }
}
