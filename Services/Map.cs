using TaskTracker.Entities;
using TaskTracker.Models;

namespace TaskTracker.Services
{
    public static class Map
    {
        public static List<TagDTO> ToTagResponseDTO(this IEnumerable<Tag> source)
        {
            return [.. source.Select(tag => new TagDTO
            {
                Id = tag.Id,
                Name = tag?.Name ?? string.Empty,
                DateCreated = tag.CreatedAt
            })];
        }

        public static TagDTO ToTagResponseDTO(this Tag source)
        {
            return new TagDTO
            {
                Id = source.Id,
                Name = source?.Name ?? string.Empty,
                DateCreated = source.CreatedAt
            };
        }

        public static List<ActivityDTO> ToActivitiesResponseDTO(this IEnumerable<Activity> source)
        {
            return [.. source.Select(activity => new ActivityDTO
            {
                Id = activity.Id,
                Title = activity.Title,
                Description = activity.Description,
                DueDate = activity.DueDate,
                IsCompleted = activity.IsCompleted,
                DateCreated = activity.CreatedAt,
            })];
        }

        public static ActivityDTO ToActivityResponseDTO(this Activity source)
        {
            return new ActivityDTO
            {
                Id = source.Id,
                Title = source.Title,
                Description = source.Description,
                DueDate = source.DueDate,
                IsCompleted = source.IsCompleted,
                DateCreated = source.CreatedAt,
            };
        }
    }
}
