using System;
using System.Data;

namespace Kursach.Infrastructure.DatabaseObjects
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public IngredientsCollection Ingredients { get; private set; }
        public double Price { get; private set; }
        public string ProductImagePath { get; private set; }
        public ProductType Type { get; private set; }

        public Product(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.Name = Convert.ToString(row["p_name"]);
            this.Price = Convert.ToDouble(row["p_price"]);
            this.ProductImagePath = Convert.ToString(row["product_image_path"]);
            this.Type = new ProductType(this.Id);
            this.Ingredients = new IngredientsCollection(this.Id);
        }
    }
}
