using MyFitnessJourney.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.WorkoutDay
{
    public interface IWorkoutDayService : IGenericService<Data.Models.WorkoutDay, WorkoutDayServiceModel>
    {
        List<WorkoutDayServiceModel> GetByProgramId(string programId);
    }
}
