using GymApp.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace FitnessApp.Models.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName {get;set;}

        public virtual User User{get;set;}
    }
}