using MyFitnessJourney.Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Web.Models.PersonalBest
{
    public class CreatePersonalBestModel
    {
        public string Exercise { get; set; }

        public double Weight { get; set; }

        [NotInFuture]
        public DateTime Date { get; set; }
    }
}
