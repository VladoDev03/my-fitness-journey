using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFitnessJourney.Service.Exercise;
using MyFitnessJourney.Service.Models.Exercise;
using MyFitnessJourney.Web.Models.Exercise;

namespace MyFitnessJourney.Web.Controllers
{
    [Authorize]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExerciseModel exercise)
        {
            if (!ModelState.IsValid)
            {
                return View(exercise);
            }

            ExerciseServiceModel exerciseServiceModel = new ExerciseServiceModel
            {
                Name = exercise.Name,
            };

            try
            {
                await _exerciseService.CreateAsync(exerciseServiceModel);
                return RedirectToAction("Index", "Home");
            }
            catch (InvalidOperationException)
            {
                ModelState.AddModelError(nameof(exercise.Name), "An exercise with this name already exists.");
                return View(exercise);
            }
        }
    }
}
