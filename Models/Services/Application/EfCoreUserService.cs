using GymApp.Models.Services.Insfrastructure;
using GymApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Models.Services.Application
{
    public class EfCoreUserService : IUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly AppDbContext dbContext;
        public EfCoreUserService(IHttpContextAccessor httpContextAccessor, AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserViewModel> GetUserAsync(string id)
        {
            id = httpContextAccessor.HttpContext.User.FindFirst("Id").Value;
            var user = await this.dbContext.Users.Where(user => user.Id == id)
            .Select(user => new UserViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Plans = user.Plans.Select(plan => new PlanViewModel
                {
                    Id = plan.Id,
                    UserId = plan.UserId,
                    CreationDate = plan.CreationDate,
                    StartDate = plan.StartDate,
                    EndDate = plan.EndDate
                }).ToList(),
                Measurments = user.Measurments.Select(meas => new MeasurmentViewModel
                {
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

        public Task<List<UserViewModel>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}