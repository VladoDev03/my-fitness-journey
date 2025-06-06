using Microsoft.EntityFrameworkCore;
using MyFitnessJourney.Data.Models;
using MyFitnessJourney.Data.Repositories;
using MyFitnessJourney.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.WorkoutProgram
{
    public class WorkoutProgramService : IWorkoutProgramService
    {
        private readonly WorkoutProgramRepository workoutProgramRepository;

        public WorkoutProgramService(WorkoutProgramRepository workoutProgramRepository)
        {
            this.workoutProgramRepository = workoutProgramRepository;
        }

        public async Task<WorkoutProgramServiceModel> CreateAsync(WorkoutProgramServiceModel model)
        {
            Data.Models.WorkoutProgram workoutProgram = new Data.Models.WorkoutProgram
            {
                UserId = model.UserId,
            };

            await workoutProgramRepository.CreateAsync(workoutProgram);

            return model;
        }

        public async Task<WorkoutProgramServiceModel> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<WorkoutProgramServiceModel> GetAll()
        {
            return workoutProgramRepository.GetAll()
                .Select(wp => new WorkoutProgramServiceModel
                {
                    Id = wp.Id,
                    UserId = wp.UserId,
                });
        }

        public async Task<WorkoutProgramServiceModel> GetByIdAsync(string id)
        {
            return await workoutProgramRepository.GetAllAsNoTracking()
                .Where(wp => wp.Id == id)
                .Select(wp => new WorkoutProgramServiceModel
                {
                    Id = wp.Id,
                    UserId = wp.UserId,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<WorkoutProgramServiceModel> UpdateAsync(string id, WorkoutProgramServiceModel model)
        {
            throw new NotImplementedException();
        }
    }
}
