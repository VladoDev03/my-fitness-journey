using MyFitnessJourney.Service.Models;

namespace MyFitnessJourney.Service.PersonalBest
{
    public interface IPersonalBestService : IGenericService<Data.Models.PersonalBest, PersonalBestServiceModel>
    {
        Task<PersonalBestServiceModel> CreateWithExerciseAsync(PersonalBestServiceModel model, string exerciseId);
        List<PersonalBestServiceModel> GetUserPersonalBests(string userId);
    }
}
