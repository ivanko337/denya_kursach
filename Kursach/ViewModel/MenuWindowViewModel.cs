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
                KursachDBContext dbContext = new KursachDBContext();

                IQueryable<Product> query = dbContext.Products.Include("IngridientsProducts").Include("IngridientsProducts.Ingredients");
                List<Product> products = query.ToList();

                //var products_ = from p in dbContext.Products
                //                join ingProd in dbContext.IngridientsProducts on p.Id equals ingProd.ProductId
                //                select new
                //                {
                //                    Product = p
                //                };

                return products;
            }
        }
        public string QueryCondition { get; private set; }
    }
}
