using MySql.Data.MySqlClient;
using System;
using CiA.entities;
using System.Collections.Generic;
namespace CiA.SQL.Request
{
    public class RequestStock : Request
    {

        private MySqlDataReader reader;
        private string NameAndFileType;

        public RequestStock()
        {
            NameAndFileType = "Stock.json";
        }

        public List<EntityStock> GetStock()
        {

             List<EntityStock> stockList = new List<EntityStock>();


            cmd.CommandText = "SELECT Stock.product_id, Products.product_name, Products.product_price, "
                            + "Stock.product_quantity, Stock.store_id, Stores.store_name "
                            + "FROM ((Stock INNER JOIN Products ON Products.product_id = Stock.product_ID) "
                            + "INNER JOIN Stores ON Stock.store_id = Stores.store_id);";
                 
            try
            {
                //passando a conexão com o BD no qual quero executar o comando
                cmd.Connection = bd.connect();
                //executando comando SQL e recebendo os dados do BD
                reader = cmd.ExecuteReader();
                //passando por cada linha da tabela
                while (reader.Read())
                {
                    EntityStock stock = new EntityStock();
                    //pegando os dados das colunas, convertendo
                    stock.Product_ID = (int)reader[0];
                    stock.Product_Name = (string)reader[1];
                    stock.Product_Price = (double)reader[2];
                    stock.Product_Quantity = (int)reader[3];
                    stock.Store_ID = (int)reader[4];
                    stock.Store_Name = (string)reader[5];

                    stockList.Add(stock);
                }

                string result;
                //convertendo para json 
                result = ConvertResultToJson(stockList, NameAndFileType);
                
                Console.WriteLine(result);
                bd.disconnect();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return stockList;
        }

    }


}