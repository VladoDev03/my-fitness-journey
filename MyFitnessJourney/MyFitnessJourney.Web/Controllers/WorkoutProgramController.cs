using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFitnessJourney.Service.Exercise;
using MyFitnessJourney.Service.Models.ProgramDayExercise;
using MyFitnessJourney.Service.Models.WorkoutDay;
using MyFitnessJourney.Service.Models.WorkoutProgram;
using MyFitnessJourney.Service.ProgramDayExercise;
using MyFitnessJourney.Service.WorkoutDay;
using MyFitnessJourney.Service.WorkoutProgram;
using MyFitnessJourney.Web.Models.Exercise;
using MyFitnessJourney.Web.Models.PersonalBest;
using MyFitnessJourney.Web.Models.WorkoutProgram;
using System.Collections.Generic;

namespace MyFitnessJourney.Web.Controllers
{
    [Authorize]
    public class WorkoutProgramController : Controller
    {
        private readonly IExerciseService _exerciseService;
        private readonly IWorkoutProgramService _workoutProgramService;
        private readonly IProgramDayExerciseService _programDayExerciseService;
        private readonly IWorkoutDayService _workoutDayService;

        public WorkoutProgramController(
            IExerciseService exerciseService,
            IWorkoutProgramService workoutProgramService,
            IProgramDayExerciseService programDayExerciseService,
            IWorkoutDayService workoutDayService)
        {
            _exerciseService = exerciseService;
            _workoutProgramService = workoutProgramService;
            _programDayExerciseService = programDayExerciseService;
            _workoutDayService = workoutDayService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(bool isArchived = false)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            List<CreateWorkoutProgramModelServiceModel> result = await _workoutProgramService.FullGet(userId, isArchived);

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            WorkoutProgramViewModel result = new WorkoutProgramViewModel();

            result.Exercises = _exerciseService
                .GetAll()
                .Select(x => new ExerciseViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkoutProgramViewModel model)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            await _workoutProgramService.FullCreate(model.Program, userId);

            return RedirectToAction(nameof(GetAll));
        }

        [HttpPost]
        public async Task<IActionResult> Archive(string programId)
        {
            await _workoutProgramService.ArchiveAsync(programId);

            return RedirectToAction(nameof(GetAll));
        }

        [HttpPost]
        public async Task<IActionResult> Unarchive(string programId)
        {
            await _workoutProgramService.UnarchiveAsync(programId);

            return RedirectToAction(nameof(GetAll));
        }
    }
}
