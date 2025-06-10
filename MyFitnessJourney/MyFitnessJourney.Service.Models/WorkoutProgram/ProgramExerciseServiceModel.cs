using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.Models.WorkoutProgram
{
    public class ProgramExerciseServiceModel
    {
        public string ExerciseId { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int RepsMin { get; set; }
        public int RepsMax { get; set; }
    }
}
