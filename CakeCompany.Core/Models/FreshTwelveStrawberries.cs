using CakeCompany.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeCompany.Core.Models
{
    public class FreshTwelveStrawberries : ITopping
    {
        public FreshTwelveStrawberries()
        {
            Code = "FTWS";
            Description = "Fresh Twelve Strawberries";
            Price = 6;
        }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }
    }
}
