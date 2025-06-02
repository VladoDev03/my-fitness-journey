using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFitnessJourney.Data.Models;
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

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            List<PersonalBestViewModel> bests = _personalBestService
                .GetUserPersonalBests(userId)
                .Select(pb => new PersonalBestViewModel
                {
                    Exercise = pb.Exercise.Name,
                    ExerciseId = pb.Exercise.Id,
                    Weight = pb.Weight,
                    Date = pb.Date.ToShortDateString()
                })
                .OrderBy(pb => pb.Exercise)
                .ToList();

            return View(bests);
        }

        [Authorize]
        [HttpGet("GetPerExercise/{exerciseId}")]
        public IActionResult GetPerExercise(string exerciseId)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            List<PersonalBestViewModel> bests = _personalBestService
                .GetUserPersonalBestsExercise(userId, exerciseId)
                .Select(pb => new PersonalBestViewModel
                {
                    Exercise = pb.Exercise.Name,
                    Weight = pb.Weight,
                    Date = pb.Date.ToShortDateString()
                })
                .OrderBy(pb => pb.Exercise)
                .ToList();

            return View(bests);
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

            return RedirectToAction("GetAll", "PersonalBest");
        }
    }
}
