using TaskTracker.Entities;
using TaskTracker.Models;

namespace TaskTracker.Services.Interface
{
    public interface ITagService
    {
        Task<List<TagDTO>> GetAllTags();
        Task<TagDTO> GetTagById(Guid id);
        Task<TagDTO> GetTagByName(string name);
        Task<string> CreateTag(string name);
        Task<string> UpdateTag(Guid id, string name);
        Task<string> DeleteTag(Guid id);
    }
}
