using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Web.Models.WorkoutProgram
{
    public class ExerciseInputModel
    {
        public string ExerciseId { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int RepsMin { get; set; }
        public int RepsMax { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Sets} sets of {RepsMin}-{RepsMax} reps";
        }
    }
}
