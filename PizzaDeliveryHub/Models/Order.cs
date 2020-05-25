using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDeliveryHub.Models
{
    public sealed class Order
    {
        public string OrderID { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public int DeliveryFee { get; set; }
        public string Recipient { get; set; }

        public string HouseNumber { get; set; }
        public double TotalAmountDue { get; set; }
    }
}
