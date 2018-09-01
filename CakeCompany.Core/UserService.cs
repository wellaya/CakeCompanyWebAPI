using CakeCompany.Core.Entity;
using CakeCompany.Core.Interfaces.Repositories;
using CakeCompany.Core.Interfaces.Services;
using CakeCompany.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using CakeCompany.Core.Models;
using Microsoft.Extensions.Options;
using System.Threading;

namespace CakeCompany.Core
{
    public class UserService : IUserService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        public UserService(UserManager<AppUser> userManager, ICustomerRepository customerRepository, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            _userManager = userManager;
            _customerRepository = customerRepository;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
        }
        public async Task<bool> RegisterUser(RegistrationViewModel model, CancellationToken ct = default(CancellationToken))
        {
            AppUser user = new AppUser();
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserName = model.Email;
            
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) return false;

            await _customerRepository.AddAsync(new Customer { IdentityId = user.Id, Address = model.Address, ContactNumber = model.ContactNumber }, ct);

            return true;
        }

        public async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = await _userManager.FindByNameAsync(userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }
        
    }
}
