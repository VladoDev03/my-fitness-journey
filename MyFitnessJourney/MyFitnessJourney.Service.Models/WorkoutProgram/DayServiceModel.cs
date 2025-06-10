using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.Models.WorkoutProgram
{
    public class DayServiceModel
    {
        public string DayName { get; set; }
        public List<ProgramExerciseServiceModel> Exercises { get; set; } = new List<ProgramExerciseServiceModel>();
    }
}
