namespace BumberBreakfast.Models.DatabaseModels
{
    public class Breakfast
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        //public List<string> Savory { get; set; }
        //public List<string> Sweet { get; set; }
    }
}
