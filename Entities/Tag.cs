using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTracker.Entities
{
    [Table(name:"tags")]
    public class Tag : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
    }
}
