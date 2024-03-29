using GymApp.Models.Entities;
using GymApp.Models.ViewModels;

namespace FitnessApp.Models.Services.Application
{
    public interface IEfCorePlanService
    {
        public Task<PlanViewModel> GetPlan(string id);

        public Task<UserViewModel> GetPlans();
        
        public Task AddPlan(Plan plan);
    }
}