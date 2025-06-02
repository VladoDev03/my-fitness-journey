using MyFitnessJourney.Data.Repositories;
using MyFitnessJourney.Service.Models;
using MyFitnessJourney.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFitnessJourney.Service.Exercise;

namespace MyFitnessJourney.Service.PersonalBest
{
    public class PersonalBestService : IPersonalBestService
    {
        private readonly PersonalBestRepository personalBestRepository;

        private readonly IExerciseService exerciseService;

        public PersonalBestService(
            PersonalBestRepository personalBestRepository,
            IExerciseService exerciseService)
        {
            this.personalBestRepository = personalBestRepository;
            this.exerciseService = exerciseService;
        }

        public async Task<PersonalBestServiceModel> CreateWithExerciseAsync(PersonalBestServiceModel model, string exerciseId)
        {
            Data.Models.PersonalBest personalBest = new Data.Models.PersonalBest
            {
                Weight = model.Weight,
                ExerciseId = exerciseId,
                UserId = model.UserId
            };

            personalBest = await personalBestRepository.CreateAsync(personalBest);

            return personalBest.ToServiceModel();
        }

        public Task<PersonalBestServiceModel> CreateAsync(PersonalBestServiceModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonalBestServiceModel> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PersonalBestServiceModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PersonalBestServiceModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonalBestServiceModel> UpdateAsync(string id, PersonalBestServiceModel model)
        {
            throw new NotImplementedException();
        }
    }
}
