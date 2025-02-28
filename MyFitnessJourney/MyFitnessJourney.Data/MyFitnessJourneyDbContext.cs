using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyFitnessJourney.Web.Data;

public class MyFitnessJourneyDbContext : IdentityDbContext
{
    public MyFitnessJourneyDbContext(DbContextOptions<MyFitnessJourneyDbContext> options)
        : base(options)
    {
    }
}
