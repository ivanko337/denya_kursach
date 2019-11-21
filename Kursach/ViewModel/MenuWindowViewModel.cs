using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Kursach.Infrastructure;
using Kursach.Infrastructure.DatabaseObjects;

namespace Kursach.ViewModel
{
    public class MenuWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Product> productsCollection;
        public ObservableCollection<Product> ProductsCollection
        {
            get
            {
                return productsCollection;
            }
        }
        public string QueryCondition { get; private set; }
    }
}
