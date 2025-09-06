using Newtonsoft.Json;

namespace TaskTracker.Models
{
    public class ActivityDTO
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("dueDate")]
        public DateTime DueDate { get; set; }

        [JsonProperty("isCompleted")]
        public bool IsCompleted { get; set; }

        [JsonProperty("dateCreated")]
        public DateTime DateCreated { get; set; }
    }
}
