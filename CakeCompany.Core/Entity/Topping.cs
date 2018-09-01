using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CakeCompany.Core.Entity
{
    public class Topping
    {
        public int Id { get; set; }

        public int CakeOrderId { get; set; }
        [StringLength(5)]
        [Required]
        public string Code { get; set; }

        public virtual CakeOrder CakeOrder { get; set; }
    }
}
