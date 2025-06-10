using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.Models.WorkoutProgram
{
    public class CreateWorkoutProgramModelServiceModel
    {
        public List<DayServiceModel> Days { get; set; } = new List<DayServiceModel>();
    }
}
