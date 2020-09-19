using System;
using CiA.classes;
using System.Collections.Generic;
using CiA.entities;
using CiA.JSON;
namespace CiA
{
    class Program
    {
        static void Main()
        {
        
            
            bool programControl = true;

            while (programControl == true)
            {
                Console.WriteLine("\n\n[1] Visualizar Estoque"
                                + "\n[2] Visualizar Pedidos"
                                + "\n[3] Resumo Geral"
                                + "\n[0] Sair do programa"
                                + "\n\nopção: ");
                string inputMenu;
                inputMenu = Console.ReadLine();
                Console.WriteLine("\n");

                switch (inputMenu)
                {
                    case "1":
                        Stock stock = new Stock();
                        stock.Resume();
                        break;
                    case "2":
                        Order order = new Order();
                        order.Resume();
                        break;
                    case "3":

                        List<Entities> entitiesList = new List<Entities>();
                        Entities entities = new Entities();
                        Stock stockList = new Stock();
                        Order orderList = new Order();
                        Customer customerList = new Customer();
                        Store storeList = new Store();

                        entities.Stores = storeList.Resume();
                        entities.Customers = customerList.Resume();
                        entities.Stock = stockList.Resume();
                        entities.Orders = orderList.Resume();
                        entitiesList.Add(entities);

                        string nameAndFileType;
                        nameAndFileType = "Resume.json";
                        JsonSerialize convert = new JsonSerialize();
                        string result;
                        result = convert.createJson(entitiesList, nameAndFileType);
                     

                        Console.WriteLine(result);
                        break;
                    case "0":
                        programControl = false;
                        Console.WriteLine("\nSaindo do programa...");
                        break;    
                    default:
                        Console.WriteLine("\nOpção não encontrada.\n");
                        break;
                }

            }
        }
    }
}
	
