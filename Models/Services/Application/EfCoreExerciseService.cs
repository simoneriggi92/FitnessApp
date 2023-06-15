using GymApp.Models.Entities;
using GymApp.Models.Services.Application.Interfaces;
using GymApp.Models.Services.Insfrastructure;
using GymApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Models.Services.Application;

public class EfCoreExerciseService:IEfCoreExerciseService
{
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly AppDbContext dbContext;

    public EfCoreExerciseService(IHttpContextAccessor httpContextAccessor, AppDbContext dbContext)
    {
        this.httpContextAccessor = httpContextAccessor;
        this.dbContext = dbContext;
    }

    public async Task<List<ExerciseViewModel>> GetExercises()
    {
        var reps = await this.dbContext.Reps.Select( 
                r => new RepViewModel()
                    {
                        Id = r.Id,
                        Type = r.Type
                    })
            .ToListAsync();
        
        var exercises = await this.dbContext.Exercises.Select(
            exercise => new ExerciseViewModel()
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Description = exercise.Description,
                Category = exercise.Category,
                Reps = reps
            }).ToListAsync();
        return exercises;
    }

    public async Task AddExercise(Exercise exercise)
    {
        await this.dbContext.Exercises.AddAsync(exercise);
        await this.dbContext.SaveChangesAsync();
    }
}