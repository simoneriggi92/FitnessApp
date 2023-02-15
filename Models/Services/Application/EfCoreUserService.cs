using GymApp.Models.Services.Insfrastructure;
using GymApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Models.Services.Application
{
    public class EfCoreUserService : IUserService
    {
        private readonly AppDbContext dbContext;

        public EfCoreUserService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserViewModel> GetUserAsync(string id)
        {
            var user = await dbContext.Users.Where(user => user.Username == id).Select(user => 
            new UserViewModel{
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
                ImagePath = user.ImagePath
            }).FirstAsync();

            return user;
        }

        public async Task<List<UserViewModel>> GetUsersAsync()
        {
            var users = await dbContext.Users.Select(user => 
            new UserViewModel{
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
                ImagePath = user.ImagePath
            })
            .ToListAsync();

            return users;
        }


    }
}