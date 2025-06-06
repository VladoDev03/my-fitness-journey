using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.Models
{
    public class ProgramDayExerciseServiceModel : BaseServiceModel
    {
        public int MaxReps { get; set; }
        public int MinReps { get; set; }
        public int Sets { get; set; }
        public string WorkoutDayId { get; set; }
        public string ExerciseId { get; set; }
    }
}
