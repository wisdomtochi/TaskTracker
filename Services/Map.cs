using TaskTracker.Entities;
using TaskTracker.Models.Response;

namespace TaskTracker.Services
{
    public static class Map
    {
        public static List<ActivityDTO> ToActivityResponseDTO(this IEnumerable<Activity> source)
        {
            return [.. source.Select(activity => new ActivityDTO
            {
                Id = activity.Id,
                Title = activity.Title,
                Description = activity.Description,
                DueDate = activity.DueDate,
                IsCompleted = activity.IsCompleted,
                DateCreated = activity.CreatedAt.ToString("MMM dd yyyy"),
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
                DateCreated = source.CreatedAt.ToString("MMM dd yyyy"),
            };
        }
    }
}
