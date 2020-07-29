using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDeliveryHub.Models
{
    public abstract class Pizza
    {
        public string Name { get; set; }

        public double Price { get; set; }
        
        public PizzaSize Size { get; set; }
      
        public double Amount { get; set; }

        public virtual void Compute()
        {
            switch (this.Size)
            {
                case PizzaSize.JustRight:
                {        
                        Amount = Price * 1.5;
                }
                    break;
                case PizzaSize.TooSmall:
                    {                 
                        Amount = Price * 1;                          
                    }
                    break;
                case PizzaSize.Youmightpuke:
                    {                     
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
