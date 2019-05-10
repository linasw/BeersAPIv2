using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeersApi.DTOs;
using BeersApi.Models;
using BeersApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumedBeersController : ControllerBase
    {
        private readonly IBeersService _beersService;
        private readonly IConsumedBeersService _consumedBeersService;

        public ConsumedBeersController(IBeersService beersService, IConsumedBeersService consumedBeersService)
        {
            _beersService = beersService;
            _consumedBeersService = consumedBeersService;
        }

        // GET: api/ConsumedBeers
        [HttpGet]
        public async Task<IActionResult> GetAllConsumedBeers()
        {
            Task<IEnumerable<ConsumedBeer>> taskConsumed = _consumedBeersService.GetConsumedBeers();
            Task<IEnumerable<Beer>> taskBeers = _beersService.GetAll();

            var consumed = await taskConsumed;
            var beers = await taskBeers;

            if (consumed != null)
            {
                var joinedData = (from con in consumed
                                  join b in beers on con.BeerId equals b.Id
                                  select new ConsumedBeersDto
                                  {
                                      Id = con.Id,
                                      BeerId = con.BeerId,
                                      Title = b.Title,
                                      NonAlcohol = b.NonAlcohol,
                                      Quantity = con.Quantity,
                                      Volume = b.Volume
                                  });

                return new OkObjectResult(joinedData);

            }

            return NoContent();
        }

        // POST: api/ConsumedBeers
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateConsumeBeerDto add)
        {
            if (add != null)
            {
                if (Guid.TryParse(add.BeerId, out Guid beerId))
                {
                    if (! await _consumedBeersService.Exists(beerId))
                    {
                        var consume = new ConsumedBeer
                        {
                            Id = Guid.NewGuid(),
                            BeerId = beerId,
                            Quantity = add.Quantity
                        };

                        await _consumedBeersService.Add(consume);
                        return new OkObjectResult(true);
                    }
                }
            }

            return new OkObjectResult(false); 
        }

        // PUT: api/ConsumedBeers/5
        [HttpPut("{id}/increase")]
        public async Task<IActionResult> Put(string id)
        {
            if (Guid.TryParse(id, out Guid consumeId))
            {
                var consume = await _consumedBeersService.Get(consumeId);

                if (consume != null)
                {
                    consume.Quantity = consume.Quantity + 1;
                    bool increased = await _consumedBeersService.Update(consume);

                    return new OkObjectResult(increased);
                }
            }

            return new OkObjectResult(false);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (Guid.TryParse(id, out Guid consumeId))
            {
                var removed = await _consumedBeersService.Delete(consumeId);
                return new OkObjectResult(removed);           
            }

            return new OkObjectResult(false);
        }
    }
}
