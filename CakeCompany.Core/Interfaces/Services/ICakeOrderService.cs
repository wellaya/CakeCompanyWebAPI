using CakeCompany.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CakeCompany.Core.Interfaces.Services
{
    public interface ICakeOrderService
    {
        Task<bool> CreateCakeOrder(CakeOrderViewModel model, CancellationToken ct = default(CancellationToken));
        Task<CakeOrderInitialDataViewModel> GetInitialData();
        Task<CakeOrderViewModel> CalculateTotalPrice(CakeOrderViewModel model);
    }
}
