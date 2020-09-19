using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using CiA.entities;
using CiA.JSON;

namespace CiA.SQL.Request
{
    public class RequestStore : Request
    {
        //instância para pegar os valores recebidos do BD
        private MySqlDataReader reader;
        private string NameAndFileType;

        public RequestStore()
        {
            NameAndFileType = "Store.json";
        }

        //pegar as lojas do BD
        public List<EntityStores> GetStores()
        {
            //instânciado lista para guardas as lojas que estão no BD
            List<EntityStores> storeList = new List<EntityStores>();
            cmd.CommandText = "SELECT * FROM STORES";

            try
            {
                //passando a conexão com o BD no qual quero executar o comando
                cmd.Connection = bd.connect();
                //executando comando SQL e recebendo os dados
                reader = cmd.ExecuteReader();

                //passando por cada linha da tabela
                while (reader.Read())
                {
                    EntityStores store = new EntityStores();
                    //pegando os dados das colunas e convertendo
                    store.Store_ID= (int)reader[0];
                    store.Store_Name = (string)reader[1];
                    //adicionando instância a lista
                    storeList.Add(store);
                }
                bd.disconnect();

                //convertendo para json 
                ConvertResultToJson(storeList, NameAndFileType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return storeList;
        }

    }


}