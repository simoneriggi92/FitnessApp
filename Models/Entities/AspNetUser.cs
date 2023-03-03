using System;
using System.Collections.Generic;
using GymApp.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace FitnessApp.Models.Entities;

public class AspNetUser:IdentityUser
{

    public string FullName { get; set; }

    public string ImagePath { get; set; }= "./profile.jpeg";

    public long PlansCompleted { get; set; } = 0;


    public virtual ICollection<Measurment> Measurments { get; } = new List<Measurment>();

    public virtual ICollection<Plan> Plans { get; } = new List<Plan>();

}
