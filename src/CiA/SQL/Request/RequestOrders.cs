using MySql.Data.MySqlClient;
using System;
using CiA.entities;
using CiA.JSON;
using System.Collections.Generic;
namespace CiA.SQL.Request
{
    public class RequestOrders : Request
    {
        private MySqlDataReader reader;
        private string NameAndFileType;

        public RequestOrders()
        {
            NameAndFileType = "Orders.json";
        }

        public List<EntityOrders> GetOrders()
        {

             List<EntityOrders> ordersList = new List<EntityOrders>();

            cmd.CommandText = "SELECT Orders.order_id, Orders.customer_id, Customers.customer_name, "
                            + "Orders.order_amount, Orders.order_status FROM Orders INNER JOIN Customers "
                            + "ON Customers.customer_id = Orders.customer_id";
            try
            {
                //passando a conexão com o BD no qual quero executar o comando
                cmd.Connection = bd.connect();
                //executando comando SQL
                reader = cmd.ExecuteReader();

               
               
                //passando por cada linha da tabela
                while (reader.Read())
                {
                    RequestOrderItem orderItem = new RequestOrderItem();
                    EntityOrders order = new EntityOrders();
                    //pegando os dados das colunas e convertendo
                    order.Order_ID = (int)reader[0];
                    order.Customer_ID = (int)reader[1];
                    order.Customer_Name = (string)reader[2];
                    order.Order_Items = orderItem.GetOrderItem(order.Order_ID);
                    order.Order_Amount = (double)reader[3];
                    order.Order_Status = (string)reader[4];
                    ordersList.Add(order);


                }
                
                string result;
                //convertendo para json 
                result = ConvertResultToJson(ordersList, NameAndFileType);
                
                Console.WriteLine(result);
                bd.disconnect();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ordersList;
        }
        
    }


}