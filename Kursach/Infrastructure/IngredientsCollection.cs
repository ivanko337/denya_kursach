using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Kursach.Infrastructure.DatabaseObjects;

namespace Kursach.Infrastructure
{
    public class IngredientsCollection
    {
        public List<Ingredient> Ingredients { get; private set; }
        
        public IngredientsCollection(int productId)
        {
            // сюда будут селектнуты ингредиенты определённого блюда
            DataTable table = new DataTable();
            foreach (DataRow row in table.Rows)
            {
                Ingredients.Add(new Ingredient(row));
            }
        }
    }
}
