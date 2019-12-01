using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kursach.Infrastructure.Commands
{
    public class NotCompleteOrderCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private KursachDBContext context;

        public NotCompleteOrderCommand()
        {
            context = new KursachDBContext();
        }

        private List<Order> GetNeededNotCompletedOrders(object param)
        {
            if (!(param is int))
            {
                return null;
            }

            int id = Convert.ToInt32(param);

            var notCompletedOrders = from o in context.Orders
                                     where !o.IsCompleted
                                     where !o.IsGiven
                                     where o.Id == id
                                     select o;

            return notCompletedOrders.ToList();
        }

        public bool CanExecute(object parameter)
        {
            //var orders = GetNeededNotCompletedOrders(parameter);

            //return orders == null ? false : orders.Count == 1;
            return true;
        }

        public void Execute(object parameter)
        {
            var order = GetNeededNotCompletedOrders(parameter).First();

            if(order == null)
            {
                return;
            }

            order.IsCompleted = true;
            context.SaveChanges();
        }
    }
}
