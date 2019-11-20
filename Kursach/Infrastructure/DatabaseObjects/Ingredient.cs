using System;
using System.Data;

namespace Kursach.Infrastructure.DatabaseObjects
{
    public class Ingredient
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public IngredientType IngredientType { get; private set; }
        public double Weight { get; private set; }

        public Ingredient(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.Name = Convert.ToString(row["i_name"]);
            this.IngredientType = new IngredientType(this.Id);
        }
    }
}
