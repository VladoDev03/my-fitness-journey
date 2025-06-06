using MyFitnessJourney.Data.Repositories;
using MyFitnessJourney.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Data.Models
{
    public class WorkoutDayRepository : BaseGenericRepository<WorkoutDay>
    {
        public WorkoutDayRepository(MyFitnessJourneyDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
