using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Kursach.Infrastructure;
using Kursach.Infrastructure.DatabaseObjects;
using System.Data;
using Kursach.Model;

namespace Kursach.ViewModel
{
    public class MenuWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Product> productsCollection;
        public ObservableCollection<Product> ProductsCollection
        {
            get
            {
                if(productsCollection == null)
                {
                    productsCollection = new ObservableCollection<Product>();
                    DataTable table = Database.Instance.GetProducts(QueryCondition);
                    foreach (DataRow row in table.Rows)
                    {
                        productsCollection.Add(new Product(row));
                    }
                }
                return productsCollection;
            }
        }
        public string QueryCondition { get; private set; }
    }
}
