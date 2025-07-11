﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Data.Models
{
    public class WorkoutProgram : BaseEntity
    {
        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        public bool IsArchived { get; set; }
    }
}
