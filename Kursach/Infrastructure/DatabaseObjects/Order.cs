using System;
using System.Collections.Generic;
using System.Data;

namespace Kursach.Infrastructure.DatabaseObjects
{
    public class Order
    {
        public int Id { get; private set; }
        public double Discount { get; private set; } = 0;
        public bool IsComplete { get; private set; }
        public DateTime OrderDate { get; private set; }
        public List<Product> Products { get; private set; }

        public Order(DataRow row)
        {
            this.Id = Convert.ToInt32(row["id"]);
            this.Discount = Convert.ToDouble(row["discount"]);
            this.IsComplete = Convert.ToInt32(row["isCompleted"]) != 0;
            this.OrderDate = Convert.ToDateTime(row["order_date"]);
        }
    }
}
