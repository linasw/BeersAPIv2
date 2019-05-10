using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeersApi.Models
{
    public class ConsumedBeer
    {
        public Guid Id { get; set; }
        public Guid BeerId { get; set; }
        public int Quantity { get; set; }
    }
}
