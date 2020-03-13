using TourAgency.Bll.DTO;

namespace TourAgency.Bll.BusinessModels
{
    public static class Discount
    {
        public static int DiscountPrice(int price, int discount)
        {
            int discountForPrice = (int)(discount * price / 100.0);
            int realPrice = price - discountForPrice;
            return realPrice;
        }
    }
}
