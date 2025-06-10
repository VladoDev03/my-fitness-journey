using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.Models.Measure
{
    public class MeasureServiceModel : BaseServiceModel
    {
        public double BodyWeight { get; set; }

        public DateTime MeasureDate { get; set; }

        public string UserId { get; set; }
    }
}
