using System.IO;
using System.Text.Json;

namespace CiA.JSON
{
    public class JsonSerialize
    {
       public string createJson(object lista, string nomeJson)
       {
            var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                //passando os dados e criando arquivo JSON
                string jsonString = JsonSerializer.Serialize(lista, options);
                File.WriteAllText(@"D:\Projects\ATVD_POO\src\CiA\JSON\" + nomeJson, jsonString);
                return jsonString;
            }
       } 
}
