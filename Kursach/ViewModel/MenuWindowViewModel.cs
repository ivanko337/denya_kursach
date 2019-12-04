using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Controls;

namespace Kursach.ViewModel
{
    public class MenuWindowViewModel : ViewModelBase
    {
        public List<Product> ProductsCollection
        {
            get
            {
                KursachDBContext dbContext = new KursachDBContext();

                var query = dbContext.Products;

                return query.ToList();
            }
        }
    }
}
