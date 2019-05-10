using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeersApi.DTOs
{
    public class CreateConsumeBeerDto
    {
        public string BeerId { get; set; }
        public int Quantity { get; set; }
    }
}
