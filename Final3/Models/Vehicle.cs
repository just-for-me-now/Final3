namespace Final2.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Vin { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }



        public int OwnderId { get; set; }

        public ICollection<Claim> Claims { get; set; }
    }
}
