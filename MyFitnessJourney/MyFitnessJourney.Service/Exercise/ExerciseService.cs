using MyFitnessJourney.Data.Repositories;
using MyFitnessJourney.Service.Models;
using MyFitnessJourney.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyFitnessJourney.Service.Exercise
{
    public class ExerciseService : IExerciseService
    {
        private readonly ExerciseRepository exerciseRepository;

        public ExerciseService(ExerciseRepository exerciseRepository)
        {
            this.exerciseRepository = exerciseRepository;
        }

        public async Task<ExerciseServiceModel> CreateAsync(ExerciseServiceModel model)
        {
            if (await GetByNameAsync(model.Name) != null)
            {
                throw new ArgumentException($"Exercise with name {model.Name} already exists.");
            }

            Data.Models.Exercise exercise = new Data.Models.Exercise
            {
                Name = model.Name.ToLower(),
            };

            await exerciseRepository.CreateAsync(exercise);

            return exercise.ToServiceModel();
        }

        public async Task<ExerciseServiceModel> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ExerciseServiceModel> GetAll()
        {
            return exerciseRepository.GetAll()
                .Select(e => e.ToServiceModel());
        }

        public async Task<ExerciseServiceModel> GetByIdAsync(string id)
        {
            return (await exerciseRepository.GetAllAsNoTracking().SingleOrDefaultAsync(x => x.Id == id))?.ToServiceModel();
        }

        public async Task<ExerciseServiceModel> GetByNameAsync(string name)
        {
            return await exerciseRepository.GetAllAsNoTracking()
                .Where(x => x.Name.ToLower() == name.ToLower())
                .Select(x => x.ToServiceModel())
                .FirstOrDefaultAsync();
        }

        public async Task<ExerciseServiceModel> UpdateAsync(string id, ExerciseServiceModel model)
        {
            throw new NotImplementedException();
        }
    }
}
