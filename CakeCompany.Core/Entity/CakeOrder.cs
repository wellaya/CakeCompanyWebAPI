using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CakeCompany.Core.Entity
{
    public class CakeOrder
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [StringLength(5)]
        [Required]
        public string ShapeCode { get; set; }
        [Required]
        public int Size { get; set; }
        [MaxLength(20)]
        public string Message { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        public List<Topping> Toppings { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
