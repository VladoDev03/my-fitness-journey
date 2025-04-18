using MyFitnessJourney.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.Mapping
{
    public static class ExerciseMapping
    {
        public static ExerciseServiceModel ToServiceModel(this Data.Models.Exercise exercise)
        {
            if (exercise == null)
            {
                return null;
            }

            return new ExerciseServiceModel
            {
                Id = exercise.Id,
                Name = exercise.Name,
            };
        }

        public static Data.Models.Exercise ToEntity(this ExerciseServiceModel exerciseServiceModel)
        {
            if (exerciseServiceModel == null)
            {
                return null;
            }

            return new Data.Models.Exercise
            {
                Id = exerciseServiceModel.Id,
                Name = exerciseServiceModel.Name,
            };
        }
    }
}
