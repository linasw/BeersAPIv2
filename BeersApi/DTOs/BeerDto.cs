using System;

namespace BeersApi.DTOs
{
    public class BeerDto
    {
        public Guid BeerId { get; set; }
        public string Title { get; set; }
        public decimal Volume { get; set; }
        public bool NonAlcohol { get; set; }
    }
}
