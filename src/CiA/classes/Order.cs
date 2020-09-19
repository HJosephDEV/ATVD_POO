using CiA.SQL.Request;

namespace CiA.classes
{
    public class Order : RequestOrders
    {
        public object Resume()
        {
            object orders;
            orders = GetOrders();
            
            return orders;
        }
    }
}