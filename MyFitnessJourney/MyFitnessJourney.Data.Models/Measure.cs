using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Data.Models
{
    public class Measure : BaseEntity
    {
        public double BodyWeight { get; set; }

        public DateTime MeasureDate { get; set; }

        public string UserId { get; set; }

        public IdentityUser User { get; set; }
    }
}
