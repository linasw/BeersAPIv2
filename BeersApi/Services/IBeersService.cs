using BeersApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeersApi.Services
{
    public interface IBeersService
    {
        Task<Beer> Add(Beer bear);
        Task<bool> Delete(Guid id);
        Task<Beer> Get(Guid id);
        Task<IEnumerable<Beer>> GetAll();
        Task<bool> Update(Beer beer);
    }
}