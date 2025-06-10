using MyFitnessJourney.Service.Models.PersonalBest;

namespace MyFitnessJourney.Service.PersonalBest
{
    public interface IPersonalBestService : IGenericService<Data.Models.PersonalBest, PersonalBestServiceModel>
    {
        Task<PersonalBestServiceModel> CreateWithExerciseAsync(PersonalBestServiceModel model, string exerciseId);
        List<PersonalBestServiceModel> GetUserPersonalBests(string userId);
        List<PersonalBestServiceModel> GetUserPersonalBestsExercise(string userId, string exerciseId);
    }
}
