using MyFitnessJourney.Service.Models.Measure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.Mapping
{
    public static class MeasureMapping
    {
        public static MeasureServiceModel ToServiceModel(this Data.Models.Measure measure)
        {
            if (measure == null)
            {
                return null;
            }

            return new Service.Models.Measure.MeasureServiceModel
            {
                Id = measure.Id,
                BodyWeight = measure.BodyWeight,
                MeasureDate = measure.MeasureDate,
                UserId = measure.UserId
            };
        }
        public static Data.Models.Measure ToEntity(this MeasureServiceModel measureServiceModel)
        {
            if (measureServiceModel == null)
            {
                return null;
            }

            return new Data.Models.Measure
            {
                Id = measureServiceModel.Id,
                BodyWeight = measureServiceModel.BodyWeight,
                MeasureDate = measureServiceModel.MeasureDate,
                UserId = measureServiceModel.UserId
            };
        }
    }
}
