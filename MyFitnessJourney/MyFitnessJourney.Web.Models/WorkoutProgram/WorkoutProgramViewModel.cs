using MyFitnessJourney.Service.Models.WorkoutProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Web.Models.WorkoutProgram
{
    public class WorkoutProgramViewModel
    {
        public List<MyFitnessJourney.Web.Models.Exercise.ExerciseViewModel> Exercises { get; set; }

        public CreateWorkoutProgramModelServiceModel Program { get; set; }
    }
}
