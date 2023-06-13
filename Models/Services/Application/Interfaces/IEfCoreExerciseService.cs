using GymApp.Models.Entities;
using GymApp.Models.ViewModels;

namespace GymApp.Models.Services.Application.Interfaces;

public interface IEfCoreExerciseService
{
    public Task<List<ExerciseViewModel>> GetExercises();

    public Task AddExercise(Exercise exercise);
}