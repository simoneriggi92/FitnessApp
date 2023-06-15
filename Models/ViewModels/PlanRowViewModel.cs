namespace GymApp.Models.ViewModels;

public class PlanRowViewModel
{
    public long Id { get; set; }

    public long PlanId { get; set; }

    public long ExerciseId { get; set; }

    public long RepsId { get; set; }

    public long WeekNumber { get; set; }

    public string? Weight { get; set; }

    public string? Rest { get; set; }

    public string? Band { get; set; }

    public string? ExecutedReps { get; set; }

    public virtual ExerciseViewModel Exercise { get; set; } = null!;

    public virtual PlanViewModel Plan { get; set; } = null!;
}