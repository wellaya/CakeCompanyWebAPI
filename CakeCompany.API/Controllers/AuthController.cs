using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeCompany.Core.Helpers;
using CakeCompany.Core.Interfaces.Services;
using CakeCompany.Core.Models;
using CakeCompany.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CakeCompany.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService _UserService;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        public AuthController(IUserService UserService, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            _UserService = UserService;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
        }
        /// <summary>
        /// This API provide facility to generate user authorize token.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns>jwt</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]CredentialsViewModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = await _UserService.GetClaimsIdentity(credentials.UserName, credentials.Password);
            if (identity == null)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            }

            var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, credentials.UserName, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
            return new OkObjectResult(jwt);
        }
    }
}