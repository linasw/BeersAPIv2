using BeersApi.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeersApi.Services
{
    public class ConsumedBeersService : IConsumedBeersService
    {
        private static ConcurrentBag<ConsumedBeer> _consumedBeers;

        static ConsumedBeersService()
        {
            _consumedBeers = new ConcurrentBag<ConsumedBeer>()
            {
                new ConsumedBeer
                {
                    Id = Guid.Parse("492dda3f-51b6-48e8-b7d2-6a3254c70cd3"),
                    BeerId = Guid.Parse("01b23196-b955-4c3d-9e28-5c89dcea2cc0"),
                    Quantity = 2
                },
                new ConsumedBeer
                {
                    Id = Guid.Parse("40f18fba-9470-429c-8e8a-fb81f814050c"),
                    BeerId = Guid.Parse("f4881074-d451-4657-bf82-8cf0935d5a6c"),
                    Quantity = 2
                }
            };
        }

        public Task<IEnumerable<ConsumedBeer>> GetConsumedBeers()
        {
            return Task.FromResult<IEnumerable<ConsumedBeer>>(_consumedBeers.ToList());
        }

        public Task<ConsumedBeer> Get(Guid id)
        {
            return Task.FromResult(_consumedBeers.FirstOrDefault(x => x.Id == id));
        }

        public Task<bool> Delete(Guid id)
        {
            _consumedBeers = new ConcurrentBag<ConsumedBeer>(_consumedBeers.Where(x => x.Id != id));
            return Task.FromResult(true);
        }

        public Task<bool> Update(ConsumedBeer consumedBeer)
        {
            _consumedBeers = new ConcurrentBag<ConsumedBeer>(_consumedBeers.Where(x => x.Id != consumedBeer.Id))
            {
                consumedBeer
            };
            return Task.FromResult(true);
        }
        public Task<ConsumedBeer> Add(ConsumedBeer beer)
        {
            _consumedBeers.Add(beer);
            return Task.FromResult(beer);
        }

        public Task<bool> Exists(Guid beerId)
        {
            var beer = _consumedBeers.FirstOrDefault(c => c.BeerId == beerId);
            return Task.FromResult(beer != null);
        }
    }
}
