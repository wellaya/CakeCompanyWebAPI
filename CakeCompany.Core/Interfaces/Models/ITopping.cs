using System;
using System.Collections.Generic;
using System.Text;

namespace CakeCompany.Core.Interfaces.Models
{
    public interface ITopping
    {
        string Code { get;  }
        string Description { get;  }
        decimal Price { get;  }

        bool IsSelected { get; set; }
    }
}
