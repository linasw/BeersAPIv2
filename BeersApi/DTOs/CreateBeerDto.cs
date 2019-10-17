using System;

namespace BeersApi.DTOs
{
    public class CreateBeerDto
    {
        public Guid TypeId { get; set; }
        public string Title { get; set; }
        public bool NonAlcohol { get; set; }
        public decimal Volume { get; set; }
    }
}
