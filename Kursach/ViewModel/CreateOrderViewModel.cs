using Kursach.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kursach.ViewModel
{
    public class ViewProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICommand Command { get; set; }
        public string ImagePath { get; set; }
    }

    public class CreateOrderViewModel : ViewModelBase
    {
        public List<Product> OrderProducts { get; set; }

        public List<ViewProduct> AllProducts
        {
            get
            {
                KursachDBContext context = new KursachDBContext();

                List<ViewProduct> res = new List<ViewProduct>();
                foreach (var product in context.Products)
                {
                    res.Add(new ViewProduct()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        ImagePath = product.ProductImagePath,
                        Command = new BaseCommand(AddProductToOrder, null)
                    });
                }

                return res;
            }
        }

        private BaseCommand createOrderCommand;
        public ICommand CreateOrderCommand
        {
            get
            {
                if (createOrderCommand == null)
                {
                    createOrderCommand = new BaseCommand(CreateOrder, null);
                }

                return createOrderCommand;
            }
        }

        private double Cost
        {
            get
            {
                decimal res = 0;

                OrderProducts.ForEach(p => res += p.Price);

                return Convert.ToDouble(res);
            }
        }

        public CreateOrderViewModel()
        {
            OrderProducts = new List<Product>();
        }

        public void CreateOrder(object parameter)
        {
            using (var context = new KursachDBContext())
            {
                Order newOrder = context.Orders.Create();
                newOrder.OrderDate = DateTime.Now;
                if (Cost > 200)
                {
                    newOrder.Discount = 5;
                }

                foreach (var product in OrderProducts)
                {
                    ProductsOrder currEntity = context.ProductsOrders.Create();
                    currEntity.OrderId = newOrder.Id;
                    currEntity.ProductId = product.Id;

                    context.ProductsOrders.Add(currEntity);
                }

                context.SaveChanges();

                WorkerWindowViewModel.Instance.UpdateView();
                OrderWindowViewModel.Instance.UpdateOrder();
            }
        }

        public void AddProductToOrder(object parameter)
        {
            if (!(parameter is int))
            {
                return;
            }

            using (var context = new KursachDBContext())
            {
                int id = Convert.ToInt32(parameter);

                Product currProduct = context.Products.FirstOrDefault(p => p.Id == id);
                if (currProduct == null)
                {
                    return;
                }

                OrderProducts.Add(currProduct);
                OnProperyChanged("OrderProducts");
            }
        }
    }
}
