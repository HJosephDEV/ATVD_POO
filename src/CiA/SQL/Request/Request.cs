using MySql.Data.MySqlClient;
using System;
using CiA.JSON;

namespace CiA.SQL.Request
{
    public class Request
    {
        public ConnectionMySQL bd; 
        public MySqlCommand cmd;
        public Request()
        {
            bd = new ConnectionMySQL();
            cmd = new MySqlCommand();
        }
        public void ExecuteNonQuery(string message)
        {
               try
            {
                //passando a conexão com o BD no qual quero executar o comando
                cmd.Connection = bd.connect();
                //executando comando SQL
                cmd.ExecuteNonQuery();
                //desconectando do BD
                bd.disconnect(); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string ConvertResultToJson(object list, string NameAndFileType)
        {
            string result;
            //convertendo para json 
            JsonSerialize convertJson = new JsonSerialize();
            result = convertJson.createJson(list, NameAndFileType);
            
            return result;
        }
    }

}