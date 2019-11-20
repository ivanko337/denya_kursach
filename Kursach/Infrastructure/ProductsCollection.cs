using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kursach.Infrastructure.DatabaseObjects;
using System.Data;

namespace Kursach.Infrastructure
{
    public class ProductsCollection
    {
        public List<Product> Products { get; private set; }

        public ProductsCollection(int orderId)
        {
            DataTable table = new DataTable();

            foreach (DataRow row in table.Rows)
            {
                Products.Add(new Product(row));
            }
        }
    }
}
