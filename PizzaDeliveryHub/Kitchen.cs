using PizzaDeliveryHub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDeliveryHub
{

    public sealed class Kitchen
    {
        public Pizza CreatePizza(string pizzaName)
        {
            Pizza pizza = null;
            if (pizzaName == "all chiz")
            {
                pizza = new AllChiz();
            }
            if (pizzaName == "hawayan")
            {
                pizza = new Hawayan();
            }
            if (pizzaName == "pepperonli")
            {
                pizza = new Pepperonli();
            }

            return pizza;
        }
    }
}
