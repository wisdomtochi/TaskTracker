using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Data.Repository.Interface;
using TaskTracker.Entities;
using TaskTracker.Models.Request;
using TaskTracker.Models.Response;
using TaskTracker.Services.Interface;

namespace TaskTracker.Services.Implementation
{
    public class ActivityService(IGenericRepository<Activity> activityRepository) : IActivityService
    {
        private readonly IGenericRepository<Activity> _activityRepository = activityRepository;

        public async Task<string> CreateActivity(ActivityDTOw model)
        {
            var activity = new Activity
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                DueDate = model?.DueDate ?? DateTime.UtcNow,
                IsCompleted = false,
            };

            await _activityRepository.AddAsync(activity);
            await _activityRepository.SaveAsync();
            return "Activity created successfully";
        }

        public async Task<string> DeleteActivity(Guid id)
        {
            var activity = await _activityRepository.ReadSingleAsync(id);
            if (activity == null)
                return "Activity not found";

            activity.IsActive = false;
            _activityRepository.Update(activity);
            await _activityRepository.SaveAsync();
            return "Activity deleted successfully";
        }

        public async Task<List<ActivityDTO>> GetAllActivities()
        {
            var activities = await _activityRepository.ReadAllAsync();

            var activityDTOs = activities.ToActivityResponseDTO();
            return activityDTOs;
        }

        public async Task<ActivityDTO> GetActivityById(Guid id)
        {
            var activity = await _activityRepository.ReadSingleAsync(id);
            return activity == null ? null : activity.ToActivityResponseDTO();
        }

        public async Task<ActivityDTO> GetActivityByTitle(string title)
        {
            var trimmedName = title.Trim().ToLower();
            var activity = await _activityRepository.ReadAllQuery()
                                                    .AsNoTracking()
                                                    .Where(a => a.Title.ToLower().Contains(trimmedName))
                                                    .FirstOrDefaultAsync();
            return activity == null ? null : activity.ToActivityResponseDTO();
        }

        public async Task<string> UpdateActivity(Guid id, ActivityDTOw model)
        {
            var activity = await _activityRepository.ReadSingleAsync(id);
            if (activity == null)
                return "Activity not found";

            activity.Title = model.Title;
            activity.Description = model.Description;

            _activityRepository.Update(activity);
            await _activityRepository.SaveAsync();
            return "Activity updated successfully";
        }

        public async Task<string> SetActivityComplete(Guid id)
        {
            var activity = await _activityRepository.ReadSingleAsync(id);
            if (activity == null)
                return "Activity not found";

            activity.IsCompleted = !activity.IsCompleted;

            _activityRepository.Update(activity);
            await _activityRepository.SaveAsync();
            return "Activity updated successfully";
        }

        public async Task<List<ActivityDTO>> GetAllCompleteActivitiesAsync()
        {
            var activity = await _activityRepository.ReadAllQuery()
                                                    .AsNoTracking()
                                                    .Where(x => x.IsCompleted)
                                                    .ToListAsync();

            var activityDTOs = activity.ToActivityResponseDTO();

            return activityDTOs;
        }

        public async Task<List<ActivityDTO>> GetAllIncompleteActivitiesAsync()
        {
            var activity = await _activityRepository.ReadAllQuery()
                                                    .AsNoTracking()
                                                    .Where(x => !x.IsCompleted)
                                                    .ToListAsync();

            var activityDTOs = activity.ToActivityResponseDTO();

            return activityDTOs;
        }

        public async Task<string> UpdateDueDate(Guid id, DateTime newDueDate)
        {
            var activity =  await _activityRepository.ReadSingleAsync(id);
            if (activity == null)
                return "Activity not found";

            activity.DueDate = newDueDate;

            _activityRepository.Update(activity);
            await _activityRepository.SaveAsync();
            return "Activity due date updated successfully";
        }
    }
}