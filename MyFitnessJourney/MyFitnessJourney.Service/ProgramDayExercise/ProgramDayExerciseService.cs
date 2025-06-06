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
                SetsCount = model.SetsCount,
                WorkoutDayId = model.WorkoutDayId,
                ExerciseId = model.ExerciseId
            };

            await programDayExerciseRepository.CreateAsync(programDayExercise);

            return model;
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
                    SetsCount = pde.SetsCount,
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
                    SetsCount = pde.SetsCount,
                    WorkoutDayId = pde.WorkoutDayId,
                    ExerciseId = pde.ExerciseId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ProgramDayExerciseServiceModel> UpdateAsync(string id, ProgramDayExerciseServiceModel model)
        {
            throw new NotImplementedException();
        }
    }
}
