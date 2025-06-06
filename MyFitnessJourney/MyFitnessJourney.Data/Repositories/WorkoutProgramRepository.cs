using MyFitnessJourney.Data.Models;
using MyFitnessJourney.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Data.Repositories
{
    public class WorkoutProgramRepository : BaseGenericRepository<WorkoutProgram>
    {
        public WorkoutProgramRepository(MyFitnessJourneyDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
