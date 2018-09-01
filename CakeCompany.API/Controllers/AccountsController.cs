using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CakeCompany.Core.Interfaces.Services;
using CakeCompany.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CakeCompany.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IUserService _UserService;
        public AccountsController(IUserService UserService)
        {
            _UserService = UserService;
        }
        // POST api/accounts        
        /// <summary>
        /// This API will register new user.
        /// </summary>
        /// <param name="model">The RegistrationViewModel.</param>
        /// <param name="ct">The CancellationToken</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model, CancellationToken ct = default(CancellationToken))
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _UserService.RegisterUser(model);
            return new OkObjectResult("Account created");
        }
        
    }
}