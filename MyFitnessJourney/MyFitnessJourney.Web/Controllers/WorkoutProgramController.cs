using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFitnessJourney.Service.Exercise;
using MyFitnessJourney.Service.Models;
using MyFitnessJourney.Service.ProgramDayExercise;
using MyFitnessJourney.Service.WorkoutDay;
using MyFitnessJourney.Service.WorkoutProgram;
using MyFitnessJourney.Web.Models.Exercise;
using MyFitnessJourney.Web.Models.PersonalBest;
using MyFitnessJourney.Web.Models.WorkoutProgram;
using System.Collections.Generic;

namespace MyFitnessJourney.Web.Controllers
{
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            List<WorkoutProgramServiceModel> workoutProgramServiceModels = _workoutProgramService
                .GetAllByUserId(userId)
                .ToList();

            List<CreateWorkoutProgramModel> result = new List<CreateWorkoutProgramModel>();

            foreach (var wp in workoutProgramServiceModels)
            {
                CreateWorkoutProgramModel programModel = new CreateWorkoutProgramModel
                {
                    Days = new List<DayViewModel>()
                };

                List<WorkoutDayServiceModel> days = _workoutDayService.GetByProgramId(wp.Id);

                foreach (var day in days)
                {
                    DayViewModel dayViewModel = new DayViewModel
                    {
                        DayName = day.Name,
                        Exercises = new List<ExerciseInputModel>()
                    };

                    List<ProgramDayExerciseServiceModel> exercises = _programDayExerciseService
                        .GetByWorkoutDayId(day.Id)
                        .ToList();

                    foreach (var exercise in exercises)
                    {
                        var exerciseData = await _exerciseService.GetByIdAsync(exercise.ExerciseId);

                        ExerciseInputModel exerciseViewModel = new ExerciseInputModel
                        {
                            Name = exerciseData.Name,
                            RepsMax = exercise.MaxReps,
                            RepsMin = exercise.MinReps,
                            Sets = exercise.Sets
                        };

                        dayViewModel.Exercises.Add(exerciseViewModel);
                    }

                    programModel.Days.Add(dayViewModel);
                }

                result.Add(programModel);
            }

            return View(result);
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
        public async Task<IActionResult> Create(CreateWorkoutProgramModel model)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            WorkoutProgramServiceModel program = await _workoutProgramService.CreateAsync(new WorkoutProgramServiceModel
            {
                UserId = userId
            });

            foreach (var day in model.Days)
            {
                WorkoutDayServiceModel wDay = await _workoutDayService.CreateAsync(new WorkoutDayServiceModel
                {
                    Name = day.DayName,
                    WorkoutProgramId = program.Id
                });

                foreach (var exercise in day.Exercises)
                {
                    ProgramDayExerciseServiceModel result = await _programDayExerciseService.CreateAsync(new ProgramDayExerciseServiceModel
                    {
                        ExerciseId = exercise.ExerciseId,
                        Sets = exercise.Sets,
                        MinReps = exercise.RepsMin,
                        MaxReps = exercise.RepsMax,
                        WorkoutDayId = wDay.Id
                    });
                }
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
