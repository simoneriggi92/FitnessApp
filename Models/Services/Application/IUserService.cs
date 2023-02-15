using GymApp.Models.ViewModels;

namespace FitnessApp.Models.Services.Application
{
    public interface IUserService
    {
        public Task<UserViewModel> GetUserAsync(string id);
        public Task<List<UserViewModel>> GetUsersAsync();
    }
}