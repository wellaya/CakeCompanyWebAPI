using CakeCompany.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeCompany.Core.Models
{
    public class WhiteChocoDippedFourStrawberries : ITopping
    {
        public WhiteChocoDippedFourStrawberries()
        {
            Code = "WDFS";
            Description = "White Chocolate Dipped Four Strawberries";
            Price = 3;
        }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }
    }
}
