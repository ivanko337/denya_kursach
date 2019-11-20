using Kursach.Model;
using System;
using System.Data;

namespace Kursach.Infrastructure.DatabaseObjects
{
    public class ProductType
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        /// <summary>
        /// </summary>
        /// <param name="productId">id блюда, для которого нужно получить тип</param>
        public ProductType(int productId)
        {
            DataRow row = Database.Instance.GetProductType(productId);
            this.Id = Convert.ToInt32(row["id"]);
            this.Name = Convert.ToString(row["product_type_name"]);
        }
    }
}
