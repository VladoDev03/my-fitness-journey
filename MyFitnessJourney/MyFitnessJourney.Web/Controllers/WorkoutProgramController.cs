using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFitnessJourney.Service.Exercise;
using MyFitnessJourney.Service.PersonalBest;
using MyFitnessJourney.Web.Models.Exercise;
using MyFitnessJourney.Web.Models.WorkoutProgram;

namespace MyFitnessJourney.Web.Controllers
{
    public class WorkoutProgramController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public WorkoutProgramController(
                IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            List<ExerciseViewModel> exercises = _exerciseService
                .GetAll()
                .Select(x => new ExerciseViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();

            return View(exercises);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateWorkoutProgramModel model)
        {
            Console.WriteLine(model.ToString());

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
