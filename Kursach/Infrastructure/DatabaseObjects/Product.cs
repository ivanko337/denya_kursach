using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Kursach.Infrastructure.DatabaseObjects
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<string> Ingredients { get; private set; }
        public double Price { get; private set; }

        public Product(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.Name = Convert.ToString(row["p_name"]);
            this.Price = Convert.ToDouble(row[""]); // ещё хз где будет считаться цена
            Ingredients = null; // будет метод, который селектнет имена ингредиентов и запихнёт в коллекцию
        }
    }
}
