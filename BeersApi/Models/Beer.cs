using System;

namespace BeersApi.Models
{
    public class Beer
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool NonAlcohol { get; set; }
        public decimal Volume { get; set; }
    }
}
