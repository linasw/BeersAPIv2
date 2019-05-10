using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeersApi.DTOs
{
    public class CreateBeerDto
    {
        public string Title { get; set; }
        public bool NonAlcohol { get; set; }
        public decimal Volume { get; set; }
    }
}
