using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFitnessJourney.Data.Models;
using System.Net.Mail;

namespace MyFitnessJourney.Web.Data;

public class MyFitnessJourneyDbContext : IdentityDbContext
{
    public DbSet<Exercise> Exercises { get; set; }

    public DbSet<PersonalBest> PersonalBests { get; set; }

    public MyFitnessJourneyDbContext(DbContextOptions<MyFitnessJourneyDbContext> options)
        : base(options)
    {
    }
}
