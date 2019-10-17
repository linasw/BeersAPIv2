using System;

namespace BeersApi.DTOs
{
    public class UpdateBeerDto
    {
        public Guid TypeId { get; set; }
        public string Title { get; set; }
        public decimal Volume { get; set; }
        public bool NonAlcohol { get; set; }
    }
}
