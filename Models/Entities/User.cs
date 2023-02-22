using System;
using System.Collections.Generic;
using FitnessApp.Models.Entities;

namespace GymApp.Models.Entities;

public partial class User
{
    public long Id { get; set; }

    public string UserId {get;set;}
    public virtual ApplicationUser RegisteredUser{get;set;}

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? BirthDay { get; set; }

    public string Password { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Country { get; set; }

    public string? StateRegion { get; set; }

    public int? PlansCompleted { get; set; } = null!;

    public string? ImagePath { get; set; }

    public string? Username { get; set; }

    public virtual ICollection<Measurment> Measurments { get; } = new List<Measurment>();

    public virtual ICollection<Plan> Plans { get; } = new List<Plan>();
}
