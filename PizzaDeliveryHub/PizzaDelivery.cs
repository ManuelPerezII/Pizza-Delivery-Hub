using Newtonsoft.Json;
using PizzaDeliveryHub.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PizzaDeliveryHub
{
    public class PizzaDelivery
    {
        private List<Order> Orders;

        public PizzaDelivery()
        {
            Orders = new List<Order>();
        }
        public void ProcessOrder(string fileName)
        {
            Console.WriteLine("Started Processing Order");
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd().Replace("order id", "orderid").Replace("quarantine house number", "quarantine_house_number");
                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var item in array)
                {
                    string orderID = item.orderid;
                    Order order = Orders.Where(order => order.OrderID == orderID).FirstOrDefault();
                    
                    if(order !=null)
                    {
                        UpdateOrder(item, order);
                    }
                    else
                    {
                        CreateOrder(item);
                    }                    
                }
            }
            Console.WriteLine("Done Processing Order");
        }

        private void UpdateOrder(dynamic item, Order order)
        {
            string pizzaName = item.pizza;
            pizzaName = pizzaName.ToLower();
            Kitchen kitchen = new Kitchen();
            Pizza pizza = kitchen.CreatePizza(pizzaName);
            pizza.Size = item.size;
            pizza.Compute(GetPizzaSize(pizza.Size));
            order.Pizzas.Add(pizza);
            order.TotalAmountDue = order.TotalAmountDue + pizza.Amount;
        }

        private void CreateOrder(dynamic item)
        {
            Order order = new Order();
            order.OrderID = item.orderid;            
            order.HouseNumber = item.quarantine_house_number;
            if(order.HouseNumber.Length > 0) 
            {
                order.DeliveryFee = PizzaHelper.GetDeliveryFee(order.HouseNumber[0].ToString());
            }
            
            order.Recipient = item.name;            
            order.Pizzas = new List<Pizza>();
            string pizzaName = item.pizza;
            if (pizzaName !=null)
            {
                Kitchen kitchen = new Kitchen();
                pizzaName = pizzaName.ToLower();
                Pizza pizza = kitchen.CreatePizza(pizzaName);
                pizza.Size = item.size;
                pizza.Compute(GetPizzaSize(pizza.Size));
                order.Pizzas.Add(pizza);
                order.TotalAmountDue = pizza.Amount;
            }                
            Orders.Add(order);
        }

        private PizzaSize GetPizzaSize(string size)
        {
            if (size == "too small")
                return PizzaSize.TooSmall;
            else if (size == "You might puke")
                return PizzaSize.Youmightpuke;
            else 
                return PizzaSize.JustRight;            
        }
        
        public void ShowOrder(string orderID)
        {
            Order order = Orders.Where(order => order.OrderID == orderID).FirstOrDefault();
            if(order!= null)
            {
                Console.WriteLine("Here are the details");
                Console.WriteLine("Order ID: " + order.OrderID);
                Console.WriteLine("****************");
                Console.WriteLine("Pizza's : ");
                foreach (Pizza pizza in order.Pizzas)
                {
                    Console.WriteLine("Pizza: " + pizza.Name);
                    Console.WriteLine("Price: " + pizza.Price);
                    Console.WriteLine("Size: " + pizza.Size);
                    Console.WriteLine("Amount: " + pizza.Amount);
                    Console.WriteLine("               ");
                }
                Console.WriteLine("****************");
                Console.WriteLine("Delivery Fee: "+ order.DeliveryFee);
                Console.WriteLine("Pizza Amount: " + order.TotalAmountDue);
                Console.WriteLine("Total Amount: " + (order.TotalAmountDue + order.DeliveryFee));
                Console.WriteLine(" ");
                Console.WriteLine("Recipient: " + order.Recipient);
                Console.WriteLine("House Number: " + order.HouseNumber);

            }
            else
            {
                Console.WriteLine("Invalid Order");
            }
            
        }

    }
}
