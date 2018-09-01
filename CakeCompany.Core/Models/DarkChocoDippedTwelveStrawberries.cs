using CakeCompany.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeCompany.Core.Models
{
    public class DarkChocoDippedTwelveStrawberries : ITopping
    {
        public DarkChocoDippedTwelveStrawberries()
        {
            Code = "DDTS";
            Description = "Dark Chocolate Dipped Twelve Strawberries";
            Price = 7.5m;
        }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }
    }
}
