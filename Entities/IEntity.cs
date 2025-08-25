namespace TaskTracker.Entities
{
    public interface IEntity
    {
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
    }
}
