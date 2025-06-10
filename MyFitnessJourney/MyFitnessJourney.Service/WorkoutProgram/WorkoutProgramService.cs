using Microsoft.EntityFrameworkCore;
using MyFitnessJourney.Data.Models;
using MyFitnessJourney.Data.Repositories;
using MyFitnessJourney.Service.Exercise;
using MyFitnessJourney.Service.Models.ProgramDayExercise;
using MyFitnessJourney.Service.Models.WorkoutDay;
using MyFitnessJourney.Service.Models.WorkoutProgram;
using MyFitnessJourney.Service.ProgramDayExercise;
using MyFitnessJourney.Service.WorkoutDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Service.WorkoutProgram
{
    public class WorkoutProgramService : IWorkoutProgramService
    {
        private readonly WorkoutProgramRepository workoutProgramRepository;

        private readonly IWorkoutDayService _workoutDayService;
        private readonly IProgramDayExerciseService _programDayExerciseService;
        private readonly IExerciseService _exerciseService;

        public WorkoutProgramService(
            WorkoutProgramRepository workoutProgramRepository,
            IWorkoutDayService workoutDayService,
            IProgramDayExerciseService programDayExerciseService,
            IExerciseService exerciseService)
        {
            this.workoutProgramRepository = workoutProgramRepository;
            _workoutDayService = workoutDayService;
            _programDayExerciseService = programDayExerciseService;
            _exerciseService = exerciseService;
        }

        public async Task<WorkoutProgramServiceModel> CreateAsync(WorkoutProgramServiceModel model)
        {
            Data.Models.WorkoutProgram workoutProgram = new Data.Models.WorkoutProgram
            {
                UserId = model.UserId
            };

            Data.Models.WorkoutProgram result = await workoutProgramRepository.CreateAsync(workoutProgram);

            return new WorkoutProgramServiceModel
            {
                Id = result.Id,
                UserId = result.UserId
            };
        }

        public async Task<WorkoutProgramServiceModel> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateWorkoutProgramModelServiceModel> FullCreate(CreateWorkoutProgramModelServiceModel model, string userId)
        {
            WorkoutProgramServiceModel program = await this.CreateAsync(new WorkoutProgramServiceModel
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

            return model;
        }

        public async Task<List<CreateWorkoutProgramModelServiceModel>> FullGet(string userId)
        {
            List<WorkoutProgramServiceModel> workoutProgramServiceModels = this
                .GetAllByUserId(userId)
                .ToList();

            List<CreateWorkoutProgramModelServiceModel> result = new List<CreateWorkoutProgramModelServiceModel>();

            foreach (var wp in workoutProgramServiceModels)
            {
                CreateWorkoutProgramModelServiceModel programModel = new CreateWorkoutProgramModelServiceModel
                {
                    Days = new List<DayServiceModel>()
                };

                List<WorkoutDayServiceModel> days = _workoutDayService.GetByProgramId(wp.Id);

                foreach (var day in days)
                {
                    DayServiceModel dayViewModel = new DayServiceModel
                    {
                        DayName = day.Name,
                        Exercises = new List<ProgramExerciseServiceModel>()
                    };

                    List<ProgramDayExerciseServiceModel> exercises = _programDayExerciseService
                        .GetByWorkoutDayId(day.Id)
                        .ToList();

                    foreach (var exercise in exercises)
                    {
                        var exerciseData = await _exerciseService.GetByIdAsync(exercise.ExerciseId);

                        ProgramExerciseServiceModel exerciseViewModel = new ProgramExerciseServiceModel
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

            return result;
        }

        public IQueryable<WorkoutProgramServiceModel> GetAll()
        {
            return workoutProgramRepository.GetAll()
                .Select(wp => new WorkoutProgramServiceModel
                {
                    Id = wp.Id,
                    UserId = wp.UserId,
                });
        }

        public List<WorkoutProgramServiceModel> GetAllByUserId(string userId)
        {
            return workoutProgramRepository.GetAllAsNoTracking()
                .Where(wp => wp.UserId == userId)
                .Select(wp => new WorkoutProgramServiceModel
                {
                    Id = wp.Id,
                    UserId = wp.UserId,
                })
                .ToList();
        }

        public async Task<WorkoutProgramServiceModel> GetByIdAsync(string id)
        {
            return await workoutProgramRepository.GetAllAsNoTracking()
                .Where(wp => wp.Id == id)
                .Select(wp => new WorkoutProgramServiceModel
                {
                    Id = wp.Id,
                    UserId = wp.UserId,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<WorkoutProgramServiceModel> UpdateAsync(string id, WorkoutProgramServiceModel model)
        {
            throw new NotImplementedException();
        }
    }
}
