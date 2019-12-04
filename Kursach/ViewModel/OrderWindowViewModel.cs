using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.ViewModel
{
    public class OrderWindowViewModel : ViewModelBase
    {
        public List<Order> CompletedOrders
        {
            get
            {
                using (var dbContext = new KursachDBContext())
                {

                    var query = from o in dbContext.Orders
                                where o.IsCompleted
                                where !o.IsGiven
                                select o;

                    return query.ToList();
                }
            }
        }

        public List<Order> NotCompletedOrders
        {
            get
            {
                using (var dbContext = new KursachDBContext())
                {

                    var query = from o in dbContext.Orders
                                where !o.IsCompleted
                                where !o.IsGiven
                                select o;

                    return query.ToList();
                }
            }
        }
    }
}
