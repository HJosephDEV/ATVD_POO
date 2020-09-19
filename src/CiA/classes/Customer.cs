using CiA.SQL.Request;

namespace CiA.classes
{
    public class Customer : RequestCustomers
    {
       public object Resume()
        {
            object customers;
            customers = GetCustomers();
            
            return customers;
        }
    }
}