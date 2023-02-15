using System;
using System.Collections.Generic;

namespace GymApp.Models.Entities;

public partial class Exercise
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<PlansRow> PlansRows { get; } = new List<PlansRow>();
}
