using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Web.Models.Exercise
{
    public class ExerciseViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CapitalizedName => char.ToUpper(Name[0]) + Name.Substring(1);
    }
}
