using GymApp.Models.Entities;
using GymApp.Models.Services.Insfrastructure;
using GymApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Models.Services.Application
{

    public class EfCorePlanService : IEfCorePlanService
    {
       private readonly IHttpContextAccessor httpContextAccessor;
        private readonly AppDbContext dbContext;

        public EfCorePlanService(IHttpContextAccessor httpContextAccessor, AppDbContext dbContext)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }

        public Task<PlanViewModel> GetPlan(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserViewModel> GetPlans()
        {
            var userID = httpContextAccessor.HttpContext.User.FindFirst("Id").Value;

            var userViewModel = await this.dbContext.Users.Where(user => user.Id == userID)
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
                    EndDate = plan.EndDate,
                    Status = plan.Status
                }).ToList()
            }).FirstOrDefaultAsync();

            return userViewModel;
        }


        public async Task AddPlan(Plan plan)
        {
            var userID = httpContextAccessor.HttpContext.User.FindFirst("Id").Value;
            var userViewModel = await this.dbContext.Users.Where(user => user.Id == userID)
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
                        EndDate = plan.EndDate,
                        Status = plan.Status
                    }).ToList()
                }).FirstOrDefaultAsync();
            
            userViewModel.Plans.Add(new PlanViewModel()
            {
                Id = plan.Id,
                UserId = plan.UserId,
                CreationDate = plan.CreationDate,
                StartDate = plan.StartDate,
                EndDate = plan.EndDate,
                Status = plan.Status
            });

            await this.dbContext.SaveChangesAsync();
        }
    }
}