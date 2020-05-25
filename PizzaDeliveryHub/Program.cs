using PizzaDeliveryHub.Models;
using System;

namespace PizzaDeliveryHub
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello to Pizza Delivery Hub");
            Console.WriteLine("Processing orders from Pizza_Orders.json");    
            PizzaDelivery pizzaDelivery = new PizzaDelivery();
            pizzaDelivery.ProcessOrder(Environment.CurrentDirectory + "\\Pizza_Orders.json");

            while (true) 
            {
                Console.WriteLine("Search Order ID: ");
                var orderid = Console.ReadLine();
                pizzaDelivery.ShowOrder(orderid);
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("Do you want to Exit [Y][N]:");
                string line = Console.ReadLine(); 
                if (line.ToLower() == "y") 
                {
                    break;
                }                
            }            
        }
    }
}
