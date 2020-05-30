using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Controls;

namespace Kursach.ViewModel
{
    public class MenuWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Product> ProductsCollection
        {
            get
            {
                using (var context = new KursachDBContext())
                {
                    var query = context.Products.Include("ProductsTypes");
                    return new ObservableCollection<Product>(query);
                }
            }
        }
    }
}
