using System.ComponentModel.DataAnnotations.Schema;

namespace Final3.Models
{
    public class Owner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DriverLicense { get; set; }


        public ICollection<Vehicle>? Vehicles { get; set; }
    }
}
