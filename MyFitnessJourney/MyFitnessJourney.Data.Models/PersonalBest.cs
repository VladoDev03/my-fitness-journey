﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Data.Models
{
    public class PersonalBest : BaseEntity
    {
        public double Weight { get; set; }

        public string ExerciseId { get; set; }
    }
}
