using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeersApi.Models;
using BeersApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerTypesController : ControllerBase
    {
        private readonly IBeerTypeService _beerTypeService;

        public BeerTypesController(IBeerTypeService beerTypeService)
        {
            _beerTypeService = beerTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBeerTypes()
        {
            var beerTypes = await _beerTypeService.GetAll();

            if (beerTypes != null)
            {
                return new OkObjectResult(beerTypes);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBeerType(string id)
        {
            if (Guid.TryParse(id, out Guid beerTypeId))
            {
                var beerType = await _beerTypeService.Get(beerTypeId);

                if (beerType != null)
                {
                    return new OkObjectResult(beerType);
                }
            }

            return NoContent();
        }
    }
}