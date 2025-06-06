using MyFitnessJourney.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.WorkoutProgram
{
    public interface IWorkoutProgramService : IGenericService<Data.Models.WorkoutProgram, WorkoutProgramServiceModel>
    {
    }
}
