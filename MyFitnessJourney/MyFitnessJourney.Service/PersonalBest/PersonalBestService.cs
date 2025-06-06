using MyFitnessJourney.Data.Repositories;
using MyFitnessJourney.Service.Models;
using MyFitnessJourney.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFitnessJourney.Service.Exercise;
using Microsoft.EntityFrameworkCore;

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
                UserId = model.UserId,
                Date = DateTime.Now
            };

            personalBest = await personalBestRepository.CreateAsync(personalBest);

            return personalBest.ToServiceModel();
        }

        public async Task<PersonalBestServiceModel> CreateAsync(PersonalBestServiceModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonalBestServiceModel> DeleteAsync(string id)
        {
            Data.Models.PersonalBest personalBest = await personalBestRepository.GetAllAsNoTracking().FirstOrDefaultAsync(pb => pb.Id == id);

            if (personalBest == null)
            {
                throw new KeyNotFoundException("Personal best not found.");
            }

            await personalBestRepository.DeleteAsync(personalBest);

            return personalBest.ToServiceModel();
        }

        public IQueryable<PersonalBestServiceModel> GetAll()
        {
            return personalBestRepository
                .GetAll()
                .Select(pb => pb.ToServiceModel());
        }

        public async Task<PersonalBestServiceModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonalBestServiceModel> UpdateAsync(string id, PersonalBestServiceModel model)
        {
            throw new NotImplementedException();
        }

        public List<PersonalBestServiceModel> GetUserPersonalBests(string userId)
        {
            List<PersonalBestServiceModel> personalBests = personalBestRepository
                .GetAll()
                .Include(pb => pb.Exercise)
                .Where(pb => pb.UserId == userId)
                .AsEnumerable()
                .GroupBy(pb => pb.ExerciseId)
                .Select(g => g
                    .OrderByDescending(pb => pb.Weight)
                    .FirstOrDefault()
                )
                .Where(pb => pb != null)
                .Select(pb => pb.ToServiceModel())
                .ToList();

            return personalBests;
        }

        public List<PersonalBestServiceModel> GetUserPersonalBestsExercise(string userId, string exerciseId)
        {
            List<PersonalBestServiceModel> personalBests = personalBestRepository
                .GetAll()
                .Include(pb => pb.Exercise)
                .Where(pb => pb.UserId == userId && pb.Exercise.Id == exerciseId)
                .Select(pb => pb.ToServiceModel())
                .AsEnumerable()
                .OrderByDescending(pb => pb.Weight)
                .ToList();

            return personalBests;
        }
    }
}
