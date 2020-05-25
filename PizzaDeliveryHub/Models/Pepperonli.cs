using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDeliveryHub.Models
{
    public  class Pepperonli: Pizza
    {
        public Pepperonli()
        {
            Name = "Pepperonli";
            Price = 99.95;
        }

        public override void Compute(PizzaSize pizzaSize)
        {
            switch (pizzaSize)
            {
                case PizzaSize.JustRight:
                    {
                        Size = Size + (" (* 2)");
                        Amount = Price * 2;
                    }
                    break;
                case PizzaSize.TooSmall:
                    {
                        Size = Size + (" (* 1)");
                        Amount = Price * 1;
                    }
                    break;
                case PizzaSize.Youmightpuke:
                    {
                        Size = Size + (" (* 4)");
                        Amount = Price * 4;
                    }
                    break;
            }            
        }
    }
}
