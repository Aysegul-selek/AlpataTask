using AlpataTask.Core.Entities;

namespace AlpataEntities.Concrete
{
    public class Meeting : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string Document { get; set; }
    }
}
