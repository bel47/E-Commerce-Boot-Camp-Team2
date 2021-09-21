using ABBI.Domain.Entities;
using ABBI.Domain.Interfaces.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABBI.Application.Features
{
    public class BasketService : IBasketService
    {
        public Task DeleteBasket(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerBasket> GetBasket(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBasket(CustomerBasket basket)
        {
            throw new NotImplementedException();
        }
    }
}
