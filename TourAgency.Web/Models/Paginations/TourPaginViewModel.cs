using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourAgency.Web.Models.Paginations
{
    public class TourPaginViewModel
    {
        public List<TourViewModel> Tours { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}