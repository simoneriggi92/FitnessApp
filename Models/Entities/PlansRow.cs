using System;
using System.Collections.Generic;

namespace GymApp.Models.Entities;

public partial class PlansRow
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

    public virtual Exercise Exercise { get; set; } = null!;

    public virtual Plan Plan { get; set; } = null!;

    public virtual Rep Reps { get; set; } = null!;
}
