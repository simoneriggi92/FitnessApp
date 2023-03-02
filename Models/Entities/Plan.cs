using System;
using System.Collections.Generic;
using FitnessApp.Models.Entities;

namespace GymApp.Models.Entities;

public partial class Plan
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string? CreationDate { get; set; }

    public string? StartDate { get; set; }

    public string? EndDate { get; set; }

    public virtual ICollection<PlansRow> PlansRows { get; } = new List<PlansRow>();

    public virtual ApplicationUser User { get; set; } = null!;
}
