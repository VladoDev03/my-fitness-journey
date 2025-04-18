using MyFitnessJourney.Service.Models;
using MyFitnessJourney.Data.Models;

namespace MyFitnessJourney.Service.Mapping
{
    public static class PersonalBestMapping
    {
        public static PersonalBestServiceModel ToServiceModel(this Data.Models.PersonalBest personalBest)
        {
            if (personalBest == null)
            {
                return null;
            }

            return new PersonalBestServiceModel
            {
                Id = personalBest.Id,
                Weight = personalBest.Weight
            };
        }

        public static Data.Models.PersonalBest ToEntity(this PersonalBestServiceModel personalBestServiceModel)
        {
            if (personalBestServiceModel == null)
            {
                return null;
            }

            return new Data.Models.PersonalBest
            {
                Id = personalBestServiceModel.Id,
                Weight = personalBestServiceModel.Weight,
                ExerciseId = personalBestServiceModel.Exercise.Id
            };
        }
    }
}
