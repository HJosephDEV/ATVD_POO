using CiA.SQL.Request;

namespace CiA.classes
{
    public class Stock : RequestStock
    {
        public object Resume()
        {
            object stock;
            stock = GetStock();
            
            return stock;
        }
    }
}