using TourAgency.Bll.DTO;

namespace TourAgency.Bll.BusinessModels
{
    public static class Discount
    {
        public static int ConstCancellation { get; } = 5;
        public static int DiscountPrice(int price, int discount)
        {
            int discountForPrice = (int)(discount * price / 100.0);
            int realPrice = price - discountForPrice;
            if (realPrice < 0)
                realPrice = 0;
            return realPrice;
        }
        public static int AddDiscount(int discount, int step, int maxDiscount)
        {
            int newDiscount = discount;
            if (discount + step <= maxDiscount)
                newDiscount = discount + step;
            else
                newDiscount = maxDiscount;
            return newDiscount;
        }
        public static int ReduceDiscount(int discount)
        {
            int newDiscount = discount;
            if (discount - ConstCancellation >= 0)
                newDiscount = discount - ConstCancellation;
            else
                newDiscount = 0;
            return newDiscount;
        }
    }
}
