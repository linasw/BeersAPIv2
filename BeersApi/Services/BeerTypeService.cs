using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeersApi.Models;

namespace BeersApi.Services
{
    public class BeerTypeService : IBeerTypeService
    {
        private static ConcurrentBag<BeerType> _beerTypes;

        static BeerTypeService()
        {
            _beerTypes = new ConcurrentBag<BeerType>
            {
                new BeerType
                {
                    Id = Guid.Parse("b232fa7e-5f69-4be8-a554-aedf88aebb87"),
                    Name = "Pale Ale"
                },
                new BeerType
                {
                    Id = Guid.Parse("e30335c1-9362-4160-8656-c7c76075fdd5"),
                    Name = "India Pale Ale"
                },
                new BeerType
                {
                    Id = Guid.Parse("67e07987-ad13-4a83-8f66-6ff8b65b040b"),
                    Name = "Stout"
                },
                new BeerType
                {
                    Id = Guid.Parse("b7aa9c2b-3f16-4d6a-8c3d-998aac86ffe2"),
                    Name = "Wheat Beer"
                },
                new BeerType
                {
                    Id = Guid.Parse("98ee6b77-00b4-4bbf-9ded-546ce2ebb821"),
                    Name = "Lager"
                },
                new BeerType
                {
                    Id = Guid.Parse("98c4e440-ceb8-45ab-8156-2579bc6e38e8"),
                    Name = "Pilsner"
                }
            };
        }

        public Task<BeerType> Get(Guid id)
        {
            return Task.FromResult(_beerTypes.FirstOrDefault(x => x.Id == id));
        }

        public Task<IEnumerable<BeerType>> GetAll()
        {
            return Task.FromResult<IEnumerable<BeerType>>(_beerTypes);
        }
    }
}
