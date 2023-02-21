using GymApp.Models.ViewModels;

namespace GymApp.Models.Services.Application
{
    public interface IUserService
    {
        public Task<UserViewModel> GetUserAsync(string id);
        public Task<List<UserViewModel>> GetUsersAsync();
    }
}