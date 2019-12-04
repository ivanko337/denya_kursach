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
        public List<Product> OrderProducts { get; private set; }

        public List<ViewProduct> AllProducts
        {
            get
            {
                KursachDBContext context = new KursachDBContext();

                var query = from p in context.Products
                            select new ViewProduct
                            {
                                Id = p.Id,
                                Name = p.Name,
                                ImagePath = p.ProductImagePath,
                                Command = new BaseCommand(AddProductToOrder, null)
                            };

                return query.ToList();
            }
        }

        public void AddProductToOrder(object parameter)
        {
            if(!(parameter is int))
            {
                return;
            }

            var context = new KursachDBContext();
            int id = Convert.ToInt32(parameter);

            Product currProduct = context.Products.FirstOrDefault(p => p.Id == id);
            if(currProduct == null)
            {
                return;
            }

            OrderProducts.Add(currProduct);
        }
    }
}
