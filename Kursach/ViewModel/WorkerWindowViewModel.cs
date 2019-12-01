using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kursach.Infrastructure.Commands;

namespace Kursach.ViewModel
{
    public class WorkerWindowViewModel : ViewModelBase
    {
        public object CompletedOrders
        {
            get
            {
                var dbContext = new KursachDBContext();

                var query = from o in dbContext.Orders
                            where o.IsCompleted
                            where !o.IsGiven
                            select new
                            {
                                Id = o.Id,
                                Command = new CompleteOrderCommand()
                            };

                return query.ToList();
            }
        }

        public object NotCompletedOrders
        {
            get
            {
                var dbContext = new KursachDBContext();

                var query = from o in dbContext.Orders
                            where !o.IsCompleted
                            where !o.IsGiven
                            select new
                            {
                                Id = o.Id,
                                Command = new NotCompleteOrderCommand()
                            };

                return query.ToList();
            }
        }

        //public ICommand CompleteOrderCommand { get; } = new CompleteOrderCommand();
        //public ICommand NotCompleteOrderCommand { get; } = new NotCompleteOrderCommand();
    }
}
