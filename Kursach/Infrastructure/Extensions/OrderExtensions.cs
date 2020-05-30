namespace Kursach.Infrastructure.Extensions
{
    public static class OrderExtensions
    {
        public static decimal Total(this Order order)
        {
            decimal res = 0;

            foreach (var item in order.ProductsOrders)
            {
                res += item.Products.Price;
            }

            return res;
        }
    }
}
