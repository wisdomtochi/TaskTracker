using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskTracker.Data.Repository.Interface;
using TaskTracker.Entities;
using TaskTracker.Models;
using TaskTracker.Services.Interface;

namespace TaskTracker.Services.Implementation
{
    public class TagService(IGenericRepository<Tag> tagRepository) : ITagService
    {
        private readonly IGenericRepository<Tag> _tagRepository = tagRepository;

        public async Task<string> CreateTag(string name)
        {
            var tag = new Tag
            {
                Id = Guid.NewGuid(),
                Name = name,
            };

            await _tagRepository.AddAsync(tag);
            await _tagRepository.SaveAsync();
            return "Tag created successfully";
        }

        public async Task<string> DeleteTag(Guid id)
        {
            var tag = await _tagRepository.ReadSingleAsync(id);
            if(tag == null) return "Tag not found";

            tag.IsActive = false;

            _tagRepository.Update(tag);
            await _tagRepository.SaveAsync();
            return "Tag deleted successfully";
        }

        public async Task<List<TagDTO>> GetAllTags()
        {
            var tags = await _tagRepository.ReadAllAsync();
            
            var tagDTOs = tags.ToTagResponseDTO();

            return tagDTOs;
        }

        public async Task<TagDTO> GetTagById(Guid id)
        {
            var tag = await _tagRepository.ReadSingleAsync(id);

            if(tag == null) return null;

            var tagdto = tag.ToTagResponseDTO();
            return tagdto;
        }

        public async Task<TagDTO> GetTagByName(string name)
        {
            var tag = await _tagRepository.ReadAllQuery()
                                              .AsNoTracking()
                                              .Where(x => name.ToLower().Contains(x.Name.ToLower()))
                                              .FirstOrDefaultAsync();

            if (tag == null) return null;

            var tagdto = tag.ToTagResponseDTO();
            return tagdto;
        }

        public async Task<string> UpdateTag(Guid id, string name)
        {
            var tag = await _tagRepository.ReadSingleAsync(id);
            if(tag == null) return "Tag not found";

            tag.Name = name;

            _tagRepository.Update(tag);
            await _tagRepository.SaveAsync();
            return "Tag updated successfully";
        }
    }
}
