using FitnessApp.Models.Services.Infrastructure;
using FitnessApp.Models.ViewModels;
using GymApp.Models.Services.Insfrastructure;
using GymApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Models.Services.Application
{
    public class EfCoreLoginService : ILoginService
    {
        private readonly AppDbContext dbContext;

        public EfCoreLoginService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserViewModel> AutenticateUser(string username, string password)
        {
            var user =  await this.dbContext.Users.Where(user=> user.Username == username && user.Password == password)
            .Select(user => new UserViewModel{
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                BirthDay = user.BirthDay,
                PhoneNumber = user.PhoneNumber,
                Country = user.Country,
                StateRegion = user.StateRegion,
                PlansCompleted = user.PlansCompleted,
                ImagePath = user.ImagePath,
                Plans = user.Plans.Select(plan => new PlanViewModel{
                    Id = plan.Id,
                    UserId = plan.UserId,
                    CreationDate = plan.CreationDate,
                    StartDate = plan.StartDate,
                    EndDate = plan.EndDate
                }).ToList(),
                Measurments = user.Measurments.Select(meas =>new MeasurmentViewModel{
                    Id = meas.Id,
                    Waistline = meas.Waistline,
                    UserId = meas.UserId,
                    Bicep = meas.Bicep,
                    Calf = meas.Calf,
                    Chest = meas.Chest,
                    Gluteus = meas.Gluteus
                }).ToList()
                
            }).FirstOrDefaultAsync();

            return user;
        }
            
    }
}