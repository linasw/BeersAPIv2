using BeersApi.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeersApi.Services
{
    public class BeersService : IBeersService
    {
        private static ConcurrentBag<Beer> _beers;

        static BeersService()
        {
            _beers = new ConcurrentBag<Beer>()
            {
                new Beer
                {
                    Id = Guid.Parse("01b23196-b955-4c3d-9e28-5c89dcea2cc0"),
                    TypeId = Guid.Parse("98ee6b77-00b4-4bbf-9ded-546ce2ebb821"),
                    Title = "Heineken 0.00",
                    NonAlcohol = true,
                    Volume = 500
                },
                new Beer
                {
                    Id = Guid.Parse("54a973e7-aadd-480f-9f5b-ed0a8a68e236"),
                    TypeId = Guid.Parse("98c4e440-ceb8-45ab-8156-2579bc6e38e8"),
                    Title = "Calsberg",
                    NonAlcohol = false,
                    Volume = 300
                },
                new Beer
                {
                    Id = Guid.Parse("f4881074-d451-4657-bf82-8cf0935d5a6c"),
                    TypeId = Guid.Parse("67e07987-ad13-4a83-8f66-6ff8b65b040b"),
                    Title = "Vilniaus Tamsus",
                    NonAlcohol = false,
                    Volume = 333
                },
            };
        }

        public Task<IEnumerable<Beer>> GetAll()
        {
            return Task.FromResult<IEnumerable<Beer>>(_beers.ToList());
        }

        public Task<Beer> Get(Guid id)
        {
            return Task.FromResult(_beers.FirstOrDefault(x => x.Id == id));
        }

        public Task<bool> Delete(Guid id)
        {
            _beers = new ConcurrentBag<Beer>(_beers.Where(x => x.Id != id));
            return Task.FromResult(true);
        }

        public Task<bool> Update(Beer beer)
        {
            _beers = new ConcurrentBag<Beer>(_beers.Where(x => x.Id != beer.Id))
            {
                beer
            };
            return Task.FromResult(true);
        }
        public Task<Beer> Add(Beer beer)
        {
            _beers.Add(beer);
            return Task.FromResult(beer);
        }
    }
}
