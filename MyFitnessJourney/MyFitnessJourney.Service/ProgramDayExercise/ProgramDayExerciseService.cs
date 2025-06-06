using Microsoft.EntityFrameworkCore;
using MyFitnessJourney.Data.Repositories;
using MyFitnessJourney.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.ProgramDayExercise
{
    public class ProgramDayExerciseService : IProgramDayExerciseService
    {
        private readonly ProgramDayExerciseRepository programDayExerciseRepository;

        public ProgramDayExerciseService(ProgramDayExerciseRepository programDayExerciseRepository)
        {
            this.programDayExerciseRepository = programDayExerciseRepository;
        }

        public async Task<ProgramDayExerciseServiceModel> CreateAsync(ProgramDayExerciseServiceModel model)
        {
            Data.Models.ProgramDayExercise programDayExercise = new Data.Models.ProgramDayExercise
            {
                MaxReps = model.MaxReps,
                MinReps = model.MinReps,
                SetsCount = model.Sets,
                WorkoutDayId = model.WorkoutDayId,
                ExerciseId = model.ExerciseId
            };

            Data.Models.ProgramDayExercise result = await programDayExerciseRepository.CreateAsync(programDayExercise);

            return new ProgramDayExerciseServiceModel
            {
                Id = result.Id,
                MaxReps = result.MaxReps,
                MinReps = result.MinReps,
                Sets = result.SetsCount,
                WorkoutDayId = result.WorkoutDayId,
                ExerciseId = result.ExerciseId
            };
        }

        public async Task<ProgramDayExerciseServiceModel> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProgramDayExerciseServiceModel> GetAll()
        {
            return programDayExerciseRepository.GetAll()
                .Select(pde => new ProgramDayExerciseServiceModel
                {
                    Id = pde.Id,
                    MaxReps = pde.MaxReps,
                    MinReps = pde.MinReps,
                    Sets = pde.SetsCount,
                    WorkoutDayId = pde.WorkoutDayId,
                    ExerciseId = pde.ExerciseId
                });
        }

        public async Task<ProgramDayExerciseServiceModel> GetByIdAsync(string id)
        {
            return await programDayExerciseRepository.GetAllAsNoTracking()
                .Where(pde => pde.Id == id)
                .Select(pde => new ProgramDayExerciseServiceModel
                {
                    Id = pde.Id,
                    MaxReps = pde.MaxReps,
                    MinReps = pde.MinReps,
                    Sets = pde.SetsCount,
                    WorkoutDayId = pde.WorkoutDayId,
                    ExerciseId = pde.ExerciseId
                })
                .FirstOrDefaultAsync();
        }

        public List<ProgramDayExerciseServiceModel> GetByWorkoutDayId(string workoutDayId)
        {
            return programDayExerciseRepository.GetAllAsNoTracking()
                .Where(pde => pde.WorkoutDayId == workoutDayId)
                .Select(pde => new ProgramDayExerciseServiceModel
                {
                    Id = pde.Id,
                    MaxReps = pde.MaxReps,
                    MinReps = pde.MinReps,
                    Sets = pde.SetsCount,
                    WorkoutDayId = pde.WorkoutDayId,
                    ExerciseId = pde.ExerciseId
                })
                .ToList();
        }

        public async Task<ProgramDayExerciseServiceModel> UpdateAsync(string id, ProgramDayExerciseServiceModel model)
        {
            throw new NotImplementedException();
        }
    }
}
