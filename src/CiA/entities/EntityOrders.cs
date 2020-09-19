using System;
using System.Collections.Generic;

namespace CiA.entities
{
    public class EntityOrders
    {
        public int Order_ID { get; set; }
        public int Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public List<EntityItem> Order_Items { get; set; }
        public double Order_Amount { get; set; }
        public string Order_Status { get; set; }
    }
}