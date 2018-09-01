using System;
using System.Collections.Generic;
using System.Text;

namespace CakeCompany.Core.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; }  // navigation property
        public string Address { get; set; }
        public string ContactNumber { get; set; }
    }
}
