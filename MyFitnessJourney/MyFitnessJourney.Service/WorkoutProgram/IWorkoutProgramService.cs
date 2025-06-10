using MyFitnessJourney.Service.Models.WorkoutProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.WorkoutProgram
{
    public interface IWorkoutProgramService : IGenericService<Data.Models.WorkoutProgram, WorkoutProgramServiceModel>
    {
        List<WorkoutProgramServiceModel> GetAllByUserId(string userId);

        Task<CreateWorkoutProgramModelServiceModel> FullCreate(CreateWorkoutProgramModelServiceModel model, string userId);

        Task<List<CreateWorkoutProgramModelServiceModel>> FullGet(string userId);
    }
}
