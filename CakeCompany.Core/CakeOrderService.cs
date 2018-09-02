using CakeCompany.Core.Entity;
using CakeCompany.Core.Interfaces.Models;
using CakeCompany.Core.Interfaces.Repositories;
using CakeCompany.Core.Interfaces.Services;
using CakeCompany.Core.Models;
using CakeCompany.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CakeCompany.Core
{
    public class CakeOrderService : ICakeOrderService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICakeOrderRepository _cakeOrderRepository;
        private readonly IToppingRepository _toppingRepository;
        public CakeOrderService(ICustomerRepository customerRepository, ICakeOrderRepository cakeOrderRepository, IToppingRepository toppingRepository)
        {
            _customerRepository = customerRepository;
            _cakeOrderRepository = cakeOrderRepository;
            _toppingRepository = toppingRepository;
        }
        public async Task<bool> CreateCakeOrder(CakeOrderViewModel model, CancellationToken ct = default(CancellationToken))
        {
            Customer cus = _customerRepository.GetByIdentityId(model.IdentityId);
            var initialData = await this.GetInitialData();
            //calculate total price again
            List<string> toppings = model.Toppings.Split(',').ToList();
            ICake cake = initialData.CakeShapes.Where(x => x.Code.Trim() == model.ShapeCode.Trim()).FirstOrDefault();
            cake.Toppings = initialData.Toppings.Where(w => toppings.Any(code => code.Trim() == w.Code.Trim())).ToList();
            cake.Message = model.Message;
            cake.Size = model.Size;
            model.TotalPrice = cake.CalculatePrice();
            CakeOrder order = new CakeOrder();
            order.CustomerId = cus.Id;
            order.Message = model.Message;
            order.ShapeCode = model.ShapeCode;
            order.Size = model.Size;
            order.TotalPrice = model.TotalPrice;

            order = await _cakeOrderRepository.AddAsync(order);
            foreach (var topping in cake.Toppings)
            {
                Topping toppingEntity = new Topping();
                toppingEntity.CakeOrderId = order.Id;
                toppingEntity.Code = topping.Code;
                await _toppingRepository.AddAsync(toppingEntity);
            }
            return true;
        }

        public async Task<CakeOrderInitialDataViewModel> GetInitialData()
        {
            CakeOrderInitialDataViewModel model = new CakeOrderInitialDataViewModel();
            model.Toppings = this.GetToppings();
            model.CakeShapes = new List<Interfaces.Models.ICake>();
            model.CakeShapes.Add(new RoundCake());
            model.CakeShapes.Add(new SquareCake());
            return model;
        }

        private List<ITopping> GetToppings()
        {
            List<ITopping> toppings = new List<ITopping>();
            toppings.Add(new FreshFourStrawberries());
            toppings.Add(new FreshEightStrawberries());
            toppings.Add(new FreshTwelveStrawberries());
            toppings.Add(new WhiteChocoDippedFourStrawberries());
            toppings.Add(new WhiteChocoDippedEightStrawberries());
            toppings.Add(new WhiteChocoDippedTwelveStrawberries());
            toppings.Add(new DarkChocoDippedFourStrawberries());
            toppings.Add(new DarkChocoDippedEightStrawberries());
            toppings.Add(new DarkChocoDippedTwelveStrawberries());
            return toppings;
        }

        public async Task<CakeOrderViewModel> CalculateTotalPrice(CakeOrderViewModel model)
        {
            if (!string.IsNullOrEmpty(model.ShapeCode))
            {
                var initialData = await this.GetInitialData();
                List<string> toppings = new List<string>();
                if (model.Toppings != null)
                {
                    toppings = model.Toppings.Split(',').ToList();
                }

                ICake cake = initialData.CakeShapes.Where(x => x.Code.Trim() == model.ShapeCode.Trim()).FirstOrDefault();
                cake.Toppings = initialData.Toppings.Where(w => toppings.Any(code => code == w.Code)).ToList();
                cake.Message = model.Message;
                cake.Size = model.Size;
                model.TotalPrice = cake.CalculatePrice();
            }
            else
            {
                model.TotalPrice = 0;
            }

            return model;
        }
    }
}
