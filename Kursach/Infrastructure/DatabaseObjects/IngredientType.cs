using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Infrastructure.DatabaseObjects
{
    public class IngredientType
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        /// <summary>
        /// </summary>
        /// <param name="productId">id ингредиента, для которого нужно получить тип</param>
        public IngredientType(int ingredientId)
        {
            // тут вот будет запрос к бд по этому поводу хД
        }
    }
}
