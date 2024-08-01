namespace BuberBreakfast.Models
{
    public class Breakfast
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public DateTime LastModifiedDateTime { get; }
        public bool Savory { get; }
        public bool Sweet { get; }

        public Breakfast(Guid id, string name, string description, DateTime startDateTime, DateTime endDateTime, DateTime lastModifiedDateTime, bool savory, bool sweet)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            LastModifiedDateTime = lastModifiedDateTime;
            Savory = savory;
            Sweet = sweet;
        }
    }
}
