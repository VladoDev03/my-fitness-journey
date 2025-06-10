using MyFitnessJourney.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.Measure
{
    public interface IMeasureService : IGenericService<Data.Models.Measure, MeasureServiceModel>
    {
        IQueryable<MeasureServiceModel> GetAllByUserId(string userId);
    }
}
