namespace E_Commerce_Api.Service
{
    public class ProductServices
    {
        public static decimal PriceAfterDiscount(decimal price, decimal percent) => price - (price * (percent / 100));
    }
}
