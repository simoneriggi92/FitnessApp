using GymApp.Models.ViewModels;

namespace GymApp.Models.Services.Infrastructure
{
    public interface ILoginService
    {
        public Task<UserViewModel>AutenticateUser(string username, string password);
    }
}