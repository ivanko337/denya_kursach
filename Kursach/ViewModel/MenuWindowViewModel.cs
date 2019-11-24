using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;

namespace Kursach.ViewModel
{
    public class MenuWindowViewModel : ViewModelBase
    {
        //private ObservableCollection<Product> productsCollection;
        public List<Product> ProductsCollection
        {
            get
            {
                var dbContext = new KursachDBContext();

                IQueryable<Product> query = dbContext.Products;

                List<Product> products = query.ToList();

                return products;
            }
        }
        public string QueryCondition { get; private set; }
    }
}
