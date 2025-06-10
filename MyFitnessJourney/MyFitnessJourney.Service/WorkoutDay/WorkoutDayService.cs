using Microsoft.EntityFrameworkCore;
using MyFitnessJourney.Data.Models;
using MyFitnessJourney.Service.Models.WorkoutDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.WorkoutDay
{
    public class WorkoutDayService : IWorkoutDayService
    {
        private readonly WorkoutDayRepository workoutDayRepository;

        public WorkoutDayService(WorkoutDayRepository workoutDayRepository)
        {
            this.workoutDayRepository = workoutDayRepository;
        }

        public async Task<WorkoutDayServiceModel> CreateAsync(WorkoutDayServiceModel model)
        {
            Data.Models.WorkoutDay workoutDay = new Data.Models.WorkoutDay
            {
                Name = model.Name,
                WorkoutProgramId = model.WorkoutProgramId,
            };

            Data.Models.WorkoutDay result = await workoutDayRepository.CreateAsync(workoutDay);

            return new WorkoutDayServiceModel
            {
                Id = result.Id,
                Name = result.Name,
                WorkoutProgramId = result.WorkoutProgramId,
            };
        }

        public async Task<WorkoutDayServiceModel> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<WorkoutDayServiceModel> GetAll()
        {
            return workoutDayRepository.GetAll()
                .Select(wd => new WorkoutDayServiceModel
                {
                    Id = wd.Id,
                    Name = wd.Name,
                    WorkoutProgramId = wd.WorkoutProgramId,
                });
        }

        public async Task<WorkoutDayServiceModel> GetByIdAsync(string id)
        {
            return await workoutDayRepository.GetAllAsNoTracking()
                .Where(wd => wd.Id == id)
                .Select(wd => new WorkoutDayServiceModel
                {
                    Id = wd.Id,
                    Name = wd.Name,
                    WorkoutProgramId = wd.WorkoutProgramId,
                })
                .FirstOrDefaultAsync();
        }

        public List<WorkoutDayServiceModel> GetByProgramId(string programId)
        {
            return workoutDayRepository.GetAll()
                .Where(wd => wd.WorkoutProgramId == programId)
                .Select(wd => new WorkoutDayServiceModel
                {
                    Id = wd.Id,
                    Name = wd.Name,
                    WorkoutProgramId = wd.WorkoutProgramId,
                })
                .ToList();
        }

        public async Task<WorkoutDayServiceModel> UpdateAsync(string id, WorkoutDayServiceModel model)
        {
            throw new NotImplementedException();
        }
    }
}
