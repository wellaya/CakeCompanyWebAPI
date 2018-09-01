using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CakeCompany.Core.ViewModels
{
    public class CakeOrderViewModel
    {
        public string IdentityId { get; set; }
        [Required]
        public string ShapeCode { get; set; }
        public string Toppings { get; set; }
        [Required]
        public int Size { get; set; }
        [MaxLength(20)]
        public string Message { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
