using GymApp.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace FitnessApp.Models.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName {get;set;}
        public int PlansCompleted {get;set;} = 0;

        public string ImagePath {get;set;}

        public virtual ICollection<Plan> Plans{get;set;}
        public virtual ICollection<Measurment> Measurments{get;set;}
    }
}