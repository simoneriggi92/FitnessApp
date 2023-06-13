using GymApp.Models.Entities;

namespace GymApp.Models.ViewModels;

public class ExerciseViewModel
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
    
    public string? Category { get; set; }


    // public virtual ICollection<PlanRo> PlansRows { get; } = new List<PlansRow>();
    
    public virtual ICollection<Rep> Reps { get; set; } = new List<Rep>();

}