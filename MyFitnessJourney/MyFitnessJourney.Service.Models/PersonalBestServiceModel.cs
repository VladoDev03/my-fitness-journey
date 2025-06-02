using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.Models
{
    public class PersonalBestServiceModel : BaseServiceModel
    {
        public double Weight { get; set; }
        public ExerciseServiceModel Exercise { get; set; }
        public string UserId { get; set; }
    }
}
