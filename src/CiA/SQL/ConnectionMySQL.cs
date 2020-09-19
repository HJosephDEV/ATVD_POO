using MySql.Data.MySqlClient;
using System;

namespace CiA.SQL
{
    public class ConnectionMySQL
    {
        //variável
        private MySqlConnection conn;

        //construtor padrão 
        //Inserido dados de conexão para o banco de dados
        public ConnectionMySQL()
        {
            string connString = "Server=localhost; Database=cia; Username=root; Password=";
            conn = new MySqlConnection();
            conn.ConnectionString = connString;

        }
        
        //métodos
        public MySqlConnection connect()
        {
            //verificando se não já está desconectado
            if(conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open(); // abrindo conexão  
                
            }

            return conn;
        }

        public void disconnect()
        {
            //verificando se está conectado 
             if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close(); // fechando conexão
            }
        }
        
        
    }
}