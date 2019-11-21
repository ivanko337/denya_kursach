using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Kursach.Model
{
    public class Database
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vgrit\source\repos\Kursach\Kursach\Kursach.mdf;Integrated Security=True";

        #region Singleton
        private static readonly object lockObj = new object();
        private static Database instance = null;
        public static Database Instance
        {
            get
            {
                lock(lockObj)
                {
                    if(instance == null)
                    {
                        instance = new Database();
                    }
                    return instance;
                }
            }
        }
        #endregion

        private void ExecuteQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private DataSet LoadDataByQuery(string query)
        {
            DataSet res = new DataSet();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.FillSchema(res, SchemaType.Source);
                    adapter.Fill(res);
                }
            }

            return res;
        }

        private DataSet LoadData(string tableName, string condition)
        {
            return LoadDataByQuery("SELECT * FROM " + tableName + " " + condition);
        }

        private DataSet LoadData(string tableName)
        {
            return LoadData(tableName, "");
        }

        public DataRow GetProductType(int productId)
        {
            DataSet set = LoadData("ProductsTypes", $"WHERE id = (SELECT product_type FROM Products WHERE id = {productId})");

            return set.Tables["ProductsTypes"].Rows[0];
        }

        public DataRow GetIngredientType(int ingredientId)
        {
            DataSet set = LoadData("IngredientsTypes", $"WHERE id = (SELECT i_group FROM Ingredients WHERE id = {ingredientId})");

            return set.Tables["IngredientsTypes"].Rows[0];
        }

        public DataTable GetProductIngredients(int productId)
        {
            DataSet set = LoadData("Ingredients", $"WHERE id IN (SELECT ingredient_id FROM IngridientsProducts WHERE product_id = {productId})");

            return set.Tables["Ingredients"];
        }

        public DataTable GetOrders()
        {
            DataSet res = LoadData("Orders");

            return res.Tables["Orders"];
        }

        public DataTable GetProducts(string condition)
        {
            DataSet set = LoadData("Products", condition);

            return set.Tables["Products"];
        }

        public DataTable GetProducts()
        {
            return GetProducts("");
        }

        public void DeleteFromTable(int id, string tableName)
        {
            string query = $"DELETE FROM {tableName} WHERE id = {id}";

            ExecuteQuery(query);
        }


    }
}
