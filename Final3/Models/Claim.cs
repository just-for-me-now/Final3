namespace Final3.Models
{
    public class Claim
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? Date { get; set; }
        public long Vehicle_Id { get; set; }
    }
}
