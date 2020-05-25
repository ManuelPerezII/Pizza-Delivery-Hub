using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDeliveryHub.Models
{
    public abstract class Pizza
    {
        public string Name { get; set; }

        public double Price { get; set; }
        
        public string Size { get; set; }

        public double Amount { get; set; }

        public virtual void Compute(PizzaSize pizzaSize)
        {
            switch (pizzaSize)
            {
                case PizzaSize.JustRight:
                {
                        Size = Size + (" (* 1.5)");
                        Amount = Price * 1.5;
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

    public enum PizzaSize
    {
        TooSmall,
        JustRight,
        Youmightpuke
    }
}
