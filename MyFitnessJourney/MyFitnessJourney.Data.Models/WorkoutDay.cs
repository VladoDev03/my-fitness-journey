using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Data.Models
{
    public class WorkoutDay : BaseEntity
    {
        public string Name { get; set; }
        public string WorkoutProgramId { get; set; }
        public WorkoutProgram WorkoutProgram { get; set; }
    }
}
