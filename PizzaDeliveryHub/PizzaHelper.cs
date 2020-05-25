using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaDeliveryHub
{
    public static class PizzaHelper
    {
        public static int GetDeliveryFee(string text)
        {
            return text
                .Select(c => c - 'A' + 1)
                .Aggregate((sum, next) => sum * 26 + next);
        }
    }
}
