using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using CakeCompany.Core.Interfaces.Services;
using CakeCompany.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CakeCompany.API.Controllers
{
    [Authorize]
    [Route("api/cake-orders")]
    public class CakeOrdersController : Controller
    {
        private readonly ClaimsPrincipal _caller;
        private readonly ICakeOrderService _cakeOrderService;

        public CakeOrdersController(ICakeOrderService cakeOrderService, IHttpContextAccessor httpContextAccessor)
        {
            _cakeOrderService = cakeOrderService;
            _caller = httpContextAccessor.HttpContext.User;
        }

        // POST api/CakeOrders        
        /// <summary>
        /// This API will create a new cake order.
        /// </summary>
        /// <param name="model">The CakeOrderViewModel.</param>
        /// <param name="ct">The CancellationToken.</param>
        /// <returns>Success or Fail Message</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CakeOrderViewModel model, CancellationToken ct = default(CancellationToken))
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = _caller.Claims.Single(c => c.Type == "id");
            model.IdentityId = userId.Value;
            
            var result = await _cakeOrderService.CreateCakeOrder(model,ct);
            return new OkObjectResult("Cake Order completed !");
        }
        
    }
}
