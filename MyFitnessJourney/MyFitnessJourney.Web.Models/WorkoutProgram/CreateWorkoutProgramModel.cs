using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Web.Models.WorkoutProgram
{
    public class CreateWorkoutProgramModel
    {
        public List<DayViewModel> Days { get; set; } = new List<DayViewModel>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Workout Program:");
            foreach (var day in Days)
            {
                sb.AppendLine(day.ToString());
            }
            return sb.ToString();
        }
    }
}
