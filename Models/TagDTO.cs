using Newtonsoft.Json;

namespace TaskTracker.Models
{
    public class TagDTO
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date_created")]
        public DateTime DateCreated { get; set; }
    }
}
