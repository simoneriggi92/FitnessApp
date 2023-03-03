using GymApp.Models.ViewModels;

namespace GymApp.Models.Services.Application
{
    public interface IEfCoreUserService
    {
        public Task<UserViewModel> GetUserAsync(string id);
        public Task<List<UserViewModel>> GetUsersAsync();
    }
}