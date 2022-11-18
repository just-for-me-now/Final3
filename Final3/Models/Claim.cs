using System.ComponentModel.DataAnnotations.Schema;

namespace Final3.Models
{
    public class Claim
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? Date { get; set; }
        public long VehicleId { get; set; }
    }
}
