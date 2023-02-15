using System;
using System.Collections.Generic;

namespace GymApp.Models.Entities;

public partial class Measurment
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string? Chest { get; set; }

    public string? Bicep { get; set; }

    public string? Gluteus { get; set; }

    public string? Calf { get; set; }

    public string? Waistline { get; set; }

    public virtual User User { get; set; } = null!;
}
