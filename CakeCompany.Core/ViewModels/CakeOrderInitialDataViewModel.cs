using CakeCompany.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeCompany.Core.ViewModels
{
    public class CakeOrderInitialDataViewModel
    {
        public List<ICake> CakeShapes { get; set; }
        public List<ITopping> Toppings { get; set; }
        
    }
}
