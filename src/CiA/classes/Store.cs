using CiA.SQL.Request;
using CiA.entities;
namespace CiA.classes
{
    public class Store : RequestStore
    {
        public object Resume()
        {
            object stores;
            stores = GetStores();
            
            return stores;
        }
    }
}