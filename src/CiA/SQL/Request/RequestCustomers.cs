using MySql.Data.MySqlClient;
using System;
using CiA.entities;
using CiA.JSON;
using System.Collections.Generic;
namespace CiA.SQL.Request
{
    public class RequestCustomers : Request
    {
        private MySqlDataReader reader;
        private string NameAndFileType;

        public RequestCustomers()
        {
            NameAndFileType = "Customers.json";
        }

        public List<EntityCustomers> GetCustomers()
        {

             List<EntityCustomers> customersList = new List<EntityCustomers>();

            cmd.CommandText = "SELECT * FROM Customers";
            try
            {
                //passando a conexão com o BD no qual quero executar o comando
                cmd.Connection = bd.connect();
                //executando comando SQL
                reader = cmd.ExecuteReader();
                //instância de lista para gravar o resultado do BD para printar no console e criar um JSON

               
               
                //passando por cada linha da tabela
                while (reader.Read())
                {
                    EntityCustomers customer = new EntityCustomers();
                    //pegando os dados das colunas, convertendo
                    customer.Customer_ID = (int)reader[0];
                    customer.Customer_Name = (string)reader[1];

                    customersList.Add(customer);

                }
                //convertendo para json 
                ConvertResultToJson(customersList, NameAndFileType);
                bd.disconnect();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return customersList;
        }
        
    }


}