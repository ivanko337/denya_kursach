using Kursach.Model;
using System;
using System.Data;

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
            DataRow row = Database.Instance.GetIngredientType(ingredientId);

            this.Id = Convert.ToInt32(row["id"]);
            this.Name = Convert.ToString(row["ingredient_type_name"]);
        }
    }
}
