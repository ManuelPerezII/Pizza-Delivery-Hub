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

        public override void Compute()
        {
            switch (this.Size)
            {
                case PizzaSize.JustRight:
                    {                        
                        Amount = Price * 2;
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
}
