using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TourAgency.Bll.BusinessModels;

namespace TourAgency.Tests
{
    [TestClass]
    public class UnitTestDiscount
    {
        [TestMethod]
        public void Discount_0andAny_AnyReturned()
        {
            int discount = 0;
            int any = 5000;
            int actual = Discount.DiscountPrice(any, discount);
            Assert.AreEqual(any, actual);
        }
    }
}
