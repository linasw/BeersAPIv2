using System;

namespace BeersApi.DTOs
{
    public class ConsumedBeersDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
