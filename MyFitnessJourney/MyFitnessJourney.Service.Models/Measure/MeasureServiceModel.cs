using MyFitnessJourney.Service.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.Models.Measure
{
    public class MeasureServiceModel : BaseServiceModel
    {
        [Required(ErrorMessage = "Weight must be greater than 0.")]
        public double BodyWeight { get; set; }

        [Required(ErrorMessage = "Measure date is required.")]
        [NotInFuture]
        public DateTime MeasureDate { get; set; }

        public string? UserId { get; set; }
    }
}
