using MySql.Data.MySqlClient;
using System;
using CiA.entities;
using CiA.JSON;
using System.Collections.Generic;
namespace CiA.SQL.Request
{
    public class RequestOrderItem : Request
    {
        private MySqlDataReader reader;

        
        public List<EntityItem> GetOrderItem(int order_ID)
         {

             List<EntityItem> itemList = new List<EntityItem>();

            cmd.CommandText = "SELECT OrderItem.product_id, Products.product_name, OrderItem.product_quantity, "
                            + "OrderItem.product_price FROM OrderItem INNER JOIN Products ON OrderItem.order_id = @order_ID"
                            + " AND orderitem.product_id = products.product_id";
            

             cmd.Parameters.AddWithValue("@order_ID", order_ID);

            try
            {
                //passando a conexão com o BD no qual quero executar o comando
                cmd.Connection = bd.connect();
                //executando comando SQL
                reader = cmd.ExecuteReader();

               
               
                //passando por cada linha da tabela
                while (reader.Read())
                {
                    EntityItem item = new EntityItem();
                    //pegando os dados das colunas, convertendo
                    item.Product_ID = (int)reader[0];
                    item.Product_Name = (string)reader[1];
                    item.Product_quantity = (int)reader[2];
                    item.Product_price = (double)reader[3];
                    itemList.Add(item);
                }
                bd.disconnect();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return itemList;
        }
    }


}