using CakeCompany.Core.Entity;
using CakeCompany.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CakeCompany.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUser(RegistrationViewModel model, CancellationToken ct = default(CancellationToken));
        Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password);
        
    }
}
