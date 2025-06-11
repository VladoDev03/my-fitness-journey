using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Web.Models.Exercise
{
    public class CreateExerciseModel
    {
        [Required(ErrorMessage = "Exercise name is required.")]
        public string Name { get; set; }
    }
}
