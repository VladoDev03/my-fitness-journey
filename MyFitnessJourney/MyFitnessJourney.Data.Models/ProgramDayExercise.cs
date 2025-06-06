using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Data.Models
{
    public class ProgramDayExercise : BaseEntity
    {
        public int MinReps { get; set; }

        public int MaxReps { get; set; }

        public int SetsCount { get; set; }

        public string ExerciseId { get; set; }

        public Exercise Exercise { get; set; }

        public string WorkoutDayId { get; set; }

        public WorkoutDay WorkoutDay { get; set; }
    }
}
