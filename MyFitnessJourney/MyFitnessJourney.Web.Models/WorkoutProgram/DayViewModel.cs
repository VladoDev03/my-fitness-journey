using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Web.Models.WorkoutProgram
{
    public class DayViewModel
    {
        public string DayName { get; set; }
        public List<ExerciseInputModel> Exercises { get; set; } = new List<ExerciseInputModel>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Day:");
            foreach (var exercise in Exercises)
            {
                sb.AppendLine(exercise.ToString());
            }
            return sb.ToString();
        }
    }
}
