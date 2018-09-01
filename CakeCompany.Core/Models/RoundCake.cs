using CakeCompany.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CakeCompany.Core.Models
{
    public class RoundCake : ICake
    {
        public RoundCake()
        {
            Code = "ROC";
            Description = "Round Cake";
        }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public string Message { get; set; }
        public List<ITopping> Toppings { get; set; }

        public decimal CalculatePrice()
        {
            decimal price = 5;
            if (!string.IsNullOrEmpty(Message))
            {
                price = price + 1;
            }

            if (Size != 0)
            {
                price = price + ((Size / 100) * 1);
            }
            
            if (Toppings.Count > 0)
            {
                foreach (var item in Toppings)
                {
                    price = price + item.Price;
                }
            }

            return price;
        }

        public bool IsSelected { get; set; }
    }
}