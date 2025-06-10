using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.Models.WorkoutDay
{
    public class WorkoutDayServiceModel : BaseServiceModel
    {
        public string Name { get; set; }
        public string WorkoutProgramId { get; set; }
    }
}
