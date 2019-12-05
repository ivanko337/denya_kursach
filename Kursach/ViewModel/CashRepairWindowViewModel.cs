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
                    int orderId = context.Orders.Last().Id;

                    List<Product> res = new List<Product>();


                    return res;
                }
            }
        }


    }
}
