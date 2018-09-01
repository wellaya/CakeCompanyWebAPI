using CakeCompany.Core.Interfaces.Services;
using CakeCompany.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CakeCompany.API.Controllers
{
    [Authorize]
    [Route("api/new-order")]
    public class NewOrderController : Controller
    {
        private readonly ClaimsPrincipal _caller;
        private readonly ICakeOrderService _cakeOrderService;

        public NewOrderController(ICakeOrderService cakeOrderService, IHttpContextAccessor httpContextAccessor)
        {
            _cakeOrderService = cakeOrderService;
            _caller = httpContextAccessor.HttpContext.User;
        }
        /// <summary>
        /// This API provide facility to get cake order page initial data.
        /// </summary>
        /// <returns>Cake Order initial data.</returns>
        [HttpGet("initial-data")]
        [Produces(typeof(CakeOrderInitialDataViewModel))]
        public async Task<IActionResult> GetInitialData()
        {
            try
            {
                if (await _cakeOrderService.GetInitialData() ==null)
                {
                    return NotFound();
                }
                return Ok(await _cakeOrderService.GetInitialData());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        /// <summary>
        /// This API provide facility to Calculates the total cost of Cake order.
        /// </summary>
        /// <param name="shape">The shape.</param>
        /// <param name="toppings">The toppings.</param>
        /// <param name="size">The size.</param>
        /// <param name="message">The message.</param>
        /// <returns>total cost</returns>
        [HttpGet("calculate-total-cost")]
        [Produces(typeof(CakeOrderViewModel))]
        public async Task<IActionResult> CalculateTotalCost(string shape,string toppings,int size, string message)
        {
            try
            {
                CakeOrderViewModel cakeOrderViewModel = new CakeOrderViewModel();
                cakeOrderViewModel.ShapeCode = shape;
                cakeOrderViewModel.Toppings = toppings;
                cakeOrderViewModel.Size = size;
                cakeOrderViewModel.Message = message;
                if (await _cakeOrderService.CalculateTotalPrice(cakeOrderViewModel) == null)
                {
                    return NotFound();
                }
                return Ok(await _cakeOrderService.CalculateTotalPrice(cakeOrderViewModel));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
