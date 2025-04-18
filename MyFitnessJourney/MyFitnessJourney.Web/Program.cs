using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyFitnessJourney.Data.Repositories;
using MyFitnessJourney.Service.Exercise;
using MyFitnessJourney.Service.PersonalBest;
using MyFitnessJourney.Web.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<MyFitnessJourneyDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTransient<ExerciseRepository>();
builder.Services.AddTransient<PersonalBestRepository>();

builder.Services.AddTransient<IExerciseService, ExerciseService>();
builder.Services.AddTransient<IPersonalBestService, PersonalBestService>();

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
