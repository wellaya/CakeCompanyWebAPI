using CakeCompany.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeCompany.Core.Models
{
    public class DarkChocoDippedFourStrawberries : ITopping
    {
        public DarkChocoDippedFourStrawberries()
        {
            Code = "DDFS";
            Description = "Dark Chocolate Dipped Four Strawberries";
            Price = 2.5m;
        }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public bool IsSelected { get; set; }
    }
}
