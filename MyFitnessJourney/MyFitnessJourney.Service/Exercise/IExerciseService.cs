using MyFitnessJourney.Service.Models.Exercise;

namespace MyFitnessJourney.Service.Exercise
{
    public interface IExerciseService : IGenericService<Data.Models.Exercise, ExerciseServiceModel>
    {
        Task<ExerciseServiceModel> GetByNameAsync(string name);
    }
}
