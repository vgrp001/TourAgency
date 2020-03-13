using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourAgency.Web.Models.Paginations
{
    public class CustomerPaginViewModel
    {
        public IEnumerable<CustomerViewModel> Customers { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}