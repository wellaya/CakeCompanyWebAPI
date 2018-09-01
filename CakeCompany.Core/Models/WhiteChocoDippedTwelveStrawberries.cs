using CakeCompany.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeCompany.Core.Models
{
    public class WhiteChocoDippedTwelveStrawberries : ITopping
    {
        public WhiteChocoDippedTwelveStrawberries()
        {
            Code = "WDTS";
            Description = "White Chocolate Dipped Twelve Strawberries";
            Price = 9;
        }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }
    }
}
