using CakeCompany.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeCompany.Core.Interfaces.Models
{
    public interface ICake
    {
        string Code { get; set; }
        string Description { get; set; }

        int Size { get; set; }

        string Message { get; set; }

        List<ITopping> Toppings { get; set; }

        decimal CalculatePrice();
        bool IsSelected { get; set; }
    }
}
