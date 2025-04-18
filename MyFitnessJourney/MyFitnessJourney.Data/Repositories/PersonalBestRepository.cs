using MyFitnessJourney.Data.Models;
using MyFitnessJourney.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Data.Repositories
{
    public class PersonalBestRepository : BaseGenericRepository<PersonalBest>
    {
        public PersonalBestRepository(MyFitnessJourneyDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
