using BeersApi.DTOs;
using BeersApi.Models;
using BeersApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            var consumed = await taskConsumed;

            if (consumed != null)
            {
                return new OkObjectResult(consumed);

            }

            return NoContent();
        }

        // GET: api/ConsumedBeers/1
        [HttpGet("{consumptionId}")]
        public async Task<IActionResult> GetConsumptionById(string consumptionId)
        {
            if (Guid.TryParse(consumptionId, out Guid consumeId))
            {
                ConsumedBeer consumed = await _consumedBeersService.Get(consumeId);

                if (consumed != null)
                {

                    return new OkObjectResult(consumed);
                }
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuantity(string id, [FromBody] CreateConsumeBeerDto update)
        {
            if (Guid.TryParse(id, out Guid consumeId) && update != null)
            {
                var consumed = await _consumedBeersService.Get(consumeId);

                if (consumed != null && update.BeerId?.ToLower() == consumed.BeerId.ToString().ToLower())
                {
                    consumed.Quantity = update.Quantity;
                    bool updated = await _consumedBeersService.Update(consumed);
                    return new OkObjectResult(updated);
                }
                else if (Guid.TryParse(update.BeerId, out Guid beerId))
                {
                    consumed = new ConsumedBeer();

                    consumed.Id = Guid.NewGuid();
                    consumed.BeerId = beerId;
                    consumed.Quantity = update.Quantity;

                    bool updated = await _consumedBeersService.Update(consumed);
                    return new OkObjectResult(updated);
                }
            }

            return new OkObjectResult(false);
        }

        // PUT: api/ConsumedBeers/5/increase
        [HttpPut("{id}/increase")]
        public async Task<IActionResult> IncreaseQuantity(string id)
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
