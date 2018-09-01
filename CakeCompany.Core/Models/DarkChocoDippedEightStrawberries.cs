using CakeCompany.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeCompany.Core.Models
{
    public class DarkChocoDippedEightStrawberries : ITopping
    {
        public DarkChocoDippedEightStrawberries()
        {
            Code = "DDES";
            Description = "Dark Chocolate Dipped Eight Strawberries";
            Price = 5;
        }
        public string Code { get; }
        public string Description { get;  }
        public decimal Price { get; }
        public bool IsSelected { get; set; }

    }
}
