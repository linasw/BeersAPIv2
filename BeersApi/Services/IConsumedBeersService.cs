using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeersApi.Models;

namespace BeersApi.Services
{
    public interface IConsumedBeersService
    {
        Task<ConsumedBeer> Add(ConsumedBeer beer);
        Task<bool> Delete(Guid id);
        Task<ConsumedBeer> Get(Guid id);
        Task<bool> Exists(Guid beerId);
        Task<IEnumerable<ConsumedBeer>> GetConsumedBeers();
        Task<bool> Update(ConsumedBeer consumedBeer);
    }
}