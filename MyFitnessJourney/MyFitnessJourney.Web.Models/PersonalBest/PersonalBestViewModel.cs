using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Web.Models.PersonalBest
{
    public class PersonalBestViewModel
    {
        public string Id { get; set; }

        public string Exercise { get; set; }

        public string ExerciseId { get; set; }

        public double Weight { get; set; }

        public string Date { get; set; }
    }
}
