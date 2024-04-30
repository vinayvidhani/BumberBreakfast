namespace BumberBreakfast.Models
{
    public class BreakfastResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
