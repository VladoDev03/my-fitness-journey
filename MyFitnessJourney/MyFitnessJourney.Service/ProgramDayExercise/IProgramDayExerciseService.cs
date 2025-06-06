using MyFitnessJourney.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.ProgramDayExercise
{
    public interface IProgramDayExerciseService : IGenericService<Data.Models.ProgramDayExercise, ProgramDayExerciseServiceModel>
    {
        List<ProgramDayExerciseServiceModel> GetByWorkoutDayId(string workoutDayId);
    }
}
