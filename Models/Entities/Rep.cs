using System;
using System.Collections.Generic;

namespace GymApp.Models.Entities;

public partial class Rep
{
    public long Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<PlansRow> PlansRows { get; } = new List<PlansRow>();
    public virtual Exercise Exercise { get; set; } = null!;
}
