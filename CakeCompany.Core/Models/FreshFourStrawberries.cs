using CakeCompany.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeCompany.Core.Models
{
    public class FreshFourStrawberries : ITopping
    {
        public FreshFourStrawberries()
        {
            Code = "FFOS";
            Description = "Fresh Four Strawberries";
            Price = 2;
        }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }
    }
}
