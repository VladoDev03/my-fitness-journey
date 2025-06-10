using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.Mapping
{
    public static class MeasureMapping
    {
        public static Service.Models.MeasureServiceModel ToServiceModel(this Data.Models.Measure measure)
        {
            if (measure == null)
            {
                return null;
            }

            return new Service.Models.MeasureServiceModel
            {
                Id = measure.Id,
                BodyWeight = measure.BodyWeight,
                MeasureDate = measure.MeasureDate,
                UserId = measure.UserId
            };
        }
        public static Data.Models.Measure ToEntity(this Service.Models.MeasureServiceModel measureServiceModel)
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
