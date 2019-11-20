using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // ну а сдесь делается запрос шобы получить все данные
        }
    }
}
