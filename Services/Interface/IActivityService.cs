using TaskTracker.Models.Request;
using TaskTracker.Models.Response;

namespace TaskTracker.Services.Interface
{
    public interface IActivityService
    {
        Task<string> CreateActivity(ActivityDTOw model);
        Task<string> DeleteActivity(Guid id);
        Task<ActivityDTO> GetActivityById(Guid id);
        Task<ActivityDTO> GetActivityByTitle(string title);
        Task<List<ActivityDTO>> GetAllActivities();
        Task<List<ActivityDTO>> GetAllCompleteActivitiesAsync();
        Task<List<ActivityDTO>> GetAllIncompleteActivitiesAsync();
        Task<string> SetActivityComplete(Guid id);
        Task<string> UpdateActivity(Guid id, ActivityDTOw model);
    }
}