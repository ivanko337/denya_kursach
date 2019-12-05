using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.ViewModel
{
    public class CashRepairWindowViewModel : ViewModelBase
    {
        public List<Product> Products
        {
            get
            {
                using (var context = new KursachDBContext())
                {
                    Order order = context.Orders.LastOrDefault();
                    if(order == null)
                    {
                        return new List<Product>();
                    }

                    List<Product> res = context.Products.Where((product) => order.ProductsOrders.Any(po => po.ProductId == product.Id)).ToList();

                    return res;
                }
            }
        }

        public double Cost
        {
            get
            {
                decimal res = 0;

                Products.ForEach(p => res += p.Price);

                return Convert.ToDouble(res);
            }
        }
    }
}
