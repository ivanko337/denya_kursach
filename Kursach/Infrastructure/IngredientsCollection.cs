using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Kursach.Infrastructure.DatabaseObjects;
using Kursach.Model;

namespace Kursach.Infrastructure
{
    public class IngredientsCollection
    {
        public List<Ingredient> Ingredients { get; private set; }
        
        public IngredientsCollection(int productId)
        {
            DataTable table = Database.Instance.GetProductIngredients(productId);
            foreach (DataRow row in table.Rows)
            {
                Ingredients.Add(new Ingredient(row));
            }
        }
    }
}
