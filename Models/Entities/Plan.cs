using System;
using System.Collections.Generic;

namespace GymApp.Models.Entities;

public partial class Plan
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public byte[]? CreationDate { get; set; }

    public byte[]? StartDate { get; set; }

    public byte[]? EndDate { get; set; }

    public virtual ICollection<PlansRow> PlansRows { get; } = new List<PlansRow>();

    public virtual User User { get; set; } = null!;
}
