using GymApp.Models.ViewModels;

namespace FitnessApp.Models.Services.Application
{
    public interface IUserService
    {
        public Task<UserViewModel> GetUserInfoAsync(string id);
        public Task<List<UserViewModel>> GetUsersInfoAsync();
    }
}