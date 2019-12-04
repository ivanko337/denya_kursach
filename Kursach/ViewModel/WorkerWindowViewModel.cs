using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kursach.Infrastructure.Commands;
using System.Windows;

namespace Kursach.ViewModel
{
    public class OrderView
    {
        public int Id { get; set; }
        public ICommand Command { get; set; }
    }

    public class WorkerWindowViewModel : ViewModelBase
    {
        private KursachDBContext context;

        public List<OrderView> CompletedOrders
        {
            get
            {
                var dbContext = new KursachDBContext();

                var orders = dbContext.Orders;
                List<OrderView> views = new List<OrderView>();
                foreach (var oView in orders)
                {
                    if (oView.IsCompleted && !oView.IsGiven)
                    {
                        views.Add(new OrderView() { Id = oView.Id, Command = new CompleteOrderCommand(CompletedOrderCommandExecuter) });
                    }
                }

                return views;
            }
        }

        public List<OrderView> NotCompletedOrders
        {
            get
            {
                var dbContext = new KursachDBContext();

                var orders = dbContext.Orders;
                List<OrderView> views = new List<OrderView>();
                foreach (var oView in orders)
                {
                    if (oView.IsCompleted)
                    {
                        continue;
                    }

                    views.Add(new OrderView() { Id = oView.Id, Command = new NotCompleteOrderCommand(NotCompetedOrderCommandExecuter) });
                }

                return views;
            }
        }

        public WorkerWindowViewModel()
        {
            context = new KursachDBContext();
        }

        private Order GetOrdersForNotCompletedCommand(object param)
        {
            if (!(param is int))
            {
                return null;
            }

            int id = Convert.ToInt32(param);

            return context.Orders.FirstOrDefault(order => order.Id == id);
        }
        private void NotCompetedOrderCommandExecuter(object parameter)
        {
            Order order = GetOrdersForNotCompletedCommand(parameter);

            if (order == null)
            {
                return;
            }

            order.IsCompleted = true;
            context.SaveChanges();

            OnProperyChanged("NotCompletedOrders");
            OnProperyChanged("CompletedOrders");
            OrderWindowViewModel.Instance.UpdateOrder();
        }

        private Order GetOrdersForCompletedCommand(object param)
        {
            if (!(param is int))
            {
                return null;
            }

            int id = Convert.ToInt32(param);

            return context.Orders.FirstOrDefault(order => order.Id == id);
        }
        private void CompletedOrderCommandExecuter(object parameter)
        {
            Order order = GetOrdersForCompletedCommand(parameter);

            if (order == null)
            {
                return;
            }

            order.IsGiven = true;
            context.SaveChanges();

            OnProperyChanged("CompletedOrders");
            OnProperyChanged("NotCompletedOrders");
            OrderWindowViewModel.Instance.UpdateOrder();
        }
    }
}
