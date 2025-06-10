using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFitnessJourney.Data.Models;

namespace MyFitnessJourney.Web.Data;

public class MyFitnessJourneyDbContext : IdentityDbContext
{
    public DbSet<Exercise> Exercises { get; set; }

    public DbSet<PersonalBest> PersonalBests { get; set; }

    public DbSet<ProgramDayExercise> ProgramDayExercises { get; set; }

    public DbSet<WorkoutDay> WorkoutDays { get; set; }

    public DbSet<WorkoutProgram> WorkoutPrograms { get; set; }

    public DbSet<Measure> Measurements { get; set; }

    public MyFitnessJourneyDbContext(DbContextOptions<MyFitnessJourneyDbContext> options)
        : base(options)
    {
    }
}
