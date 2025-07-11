using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyFitnessJourney.Data.Models;
using MyFitnessJourney.Data.Repositories;
using MyFitnessJourney.Service.Exercise;
using MyFitnessJourney.Service.Measure;
using MyFitnessJourney.Service.PersonalBest;
using MyFitnessJourney.Service.ProgramDayExercise;
using MyFitnessJourney.Service.WorkoutDay;
using MyFitnessJourney.Service.WorkoutProgram;
using MyFitnessJourney.Web.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<MyFitnessJourneyDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTransient<ExerciseRepository>();
builder.Services.AddTransient<PersonalBestRepository>();
builder.Services.AddTransient<ProgramDayExerciseRepository>();
builder.Services.AddTransient<WorkoutProgramRepository>();
builder.Services.AddTransient<WorkoutDayRepository>();
builder.Services.AddTransient<MeasureRepository>();

builder.Services.AddTransient<IExerciseService, ExerciseService>();
builder.Services.AddTransient<IPersonalBestService, PersonalBestService>();
builder.Services.AddTransient<IProgramDayExerciseService, ProgramDayExerciseService>();
builder.Services.AddTransient<IWorkoutProgramService, WorkoutProgramService>();
builder.Services.AddTransient<IWorkoutDayService, WorkoutDayService>();
builder.Services.AddTransient<IMeasureService, MeasureService>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MyFitnessJourneyDbContext>();

builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
