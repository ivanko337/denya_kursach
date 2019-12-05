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
                    Order order = context.Orders.LastOrDefault();
                    if(order == null)
                    {
                        return new ObservableCollection<Product>();
                    }

                    ObservableCollection<Product> res = new ObservableCollection<Product>(context.Products.Where((product) => order.ProductsOrders.Any(po => po.ProductId == product.Id)));

                    return res;
                }
            }
        }

        public double Cost
        {
            get
            {
                decimal res = 0;

                foreach (Product product in Products)
                {
                    res += product.Price;
                }

                return Convert.ToDouble(res);
            }
        }
    }
}
