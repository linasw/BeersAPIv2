using BeersApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeersApi.Services
{
    public interface IBeerTypeService
    {
        Task<IEnumerable<BeerType>> GetAll();
        Task<BeerType> Get(Guid id);
    }
}
