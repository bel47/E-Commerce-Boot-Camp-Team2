using ABBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABBI.Domain.Interfaces.Facade
{
    public interface IBasketService
    {

        Task<CustomerBasket> GetBasket(string basketId);
        Task UpdateBasket(CustomerBasket basket);
        Task DeleteBasket(string basketId); 
    }
}
