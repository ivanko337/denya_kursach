using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kursach.ViewModel
{
    public class CashRepairWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Product> Products
        {
            get
            {
                using (var context = new KursachDBContext())
                {
                    Order order = context.Orders.OrderByDescending(o => o.Id).FirstOrDefault();
                    if(order == null)
                    {
                        return new ObservableCollection<Product>();
                    }

                    ObservableCollection<Product> res = new ObservableCollection<Product>();
                    decimal cost = 0;

                    foreach (ProductsOrder item in context.ProductsOrders.Where(po => po.OrderId == order.Id))
                    {
                        res.Add(item.Products);
                        cost += item.Products.Price;
                    }

                    Cost = Convert.ToDouble(cost);

                    if (order.Discount != 0)
                    {
                        Discount = (Cost / 100) * order.Discount;
                        Cost = Cost - Discount;
                    }

                    return res;
                }
            }
        }

        public double Cost { get; private set; }
        public double Discount { get; private set; }
    }
}
