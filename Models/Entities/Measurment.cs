using System;
using System.Collections.Generic;
using FitnessApp.Models.Entities;

namespace GymApp.Models.Entities;

public partial class Measurment
{
    public long Id { get; set; }

    public string UserId { get; set; } = null!;

    public string? Chest { get; set; }

    public string? Bicep { get; set; }

    public string? Gluteus { get; set; }

    public string? Calf { get; set; }

    public string? Waistline { get; set; }

    public virtual AspNetUser User { get; set; } = null!;
}
