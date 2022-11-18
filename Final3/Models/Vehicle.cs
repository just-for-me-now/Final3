﻿namespace Final3.Models
{
    public class Vehicle
    {
        public long Id { get; set; }
        public string? Brand { get; set; }
        public string? Vin { get; set; }
        public string? Color { get; set; }
        public int Year { get; set; }



        public long OwnerId { get; set; }

        public ICollection<Claim>? Claims { get; set; }
    }
}
