using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Controls;
using System.Windows.Input;
using Kursach.Infrastructure.Commands;

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
                    IEnumerable<Product> productsQuery = null;

                    if (!string.IsNullOrEmpty(SearchExpr) && !string.IsNullOrWhiteSpace(SearchExpr))
                    {
                        productsQuery = context.Products.Include("ProductsTypes").Include("IngridientsProducts").Include("IngridientsProducts.Ingredient").Where(p => p.Name.Contains(SearchExpr));
                    }
                    else
                    {
                        productsQuery = context.Products.Include("ProductsTypes").Include("IngridientsProducts").Include("IngridientsProducts.Ingredient");
                    }

                    return new ObservableCollection<Product>(productsQuery);
                }
            }
        }

        public string SearchExpr { get; set; }

        public ICommand SearchCommand
        {
            get
            {
                return new BaseCommand((param) => OnProperyChanged(nameof(ProductsCollection)));
            }
        }


    }
}
