using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourAgency.Web.Models.Abstractions;

namespace TourAgency.Web.Models
{
    public class CityViewModel : BaseEntityViewModel
    {
        public string NameCity { get; set; }
    }
}