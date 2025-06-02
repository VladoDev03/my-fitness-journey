using Microsoft.AspNetCore.Mvc;
using MyFitnessJourney.Service.Exercise;
using MyFitnessJourney.Service.Models;
using MyFitnessJourney.Service.PersonalBest;
using MyFitnessJourney.Web.Models.Exercise;
using MyFitnessJourney.Web.Models.PersonalBest;

namespace MyFitnessJourney.Web.Controllers
{
    public class PersonalBestController : Controller
    {
        private readonly IPersonalBestService _personalBestService;
        private readonly IExerciseService _exerciseService;

        public PersonalBestController(
            IPersonalBestService personalBestService,
            IExerciseService exerciseService)
        {
            _personalBestService = personalBestService;
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<ExerciseViewModel> asd = _exerciseService
                .GetAll()
                .Select(x => new ExerciseViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();

            return View(asd);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePersonalBestModel personalBest)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            await _personalBestService
                .CreateWithExerciseAsync(
                    new PersonalBestServiceModel
                    {
                        Weight = personalBest.Weight,
                        UserId = userId
                    },
                    personalBest.Exercise
                );

            return RedirectToAction("Index", "Home");
        }
    }
}
