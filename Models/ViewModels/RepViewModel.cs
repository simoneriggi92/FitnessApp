namespace GymApp.Models.ViewModels;

public class RepViewModel
{
    public long Id { get; set; }
    public string Type { get; set; }

    public virtual ICollection<PlanRowViewModel> PlansRows { get; } = new List<PlanRowViewModel>();
}