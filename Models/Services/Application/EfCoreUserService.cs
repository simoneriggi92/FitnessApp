using GymApp.Models.Services.Infrastructure;
using GymApp.Models.ViewModels;

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
            // string id = http
            // var user = await this.dbContext.Users.Where(user => user.UserName == id)
            // .Select(user => new UserViewModel
            // {
            //     Id = Louser.Id,
            //     Name = user.Name,
            //     Surname = user.Surname,
            //     Username = user.Username,
            //     Password = user.Password,
            //     Email = user.Email,
            //     BirthDay = user.BirthDay,
            //     PhoneNumber = user.PhoneNumber,
            //     Country = user.Country,
            //     StateRegion = user.StateRegion,
            //     PlansCompleted = user.PlansCompleted,
            //     ImagePath = user.ImagePath,
            //     Plans = user.Plans.Select(plan => new PlanViewModel
            //     {
            //         Id = plan.Id,
            //         UserId = plan.UserId,
            //         CreationDate = plan.CreationDate,
            //         StartDate = plan.StartDate,
            //         EndDate = plan.EndDate
            //     }).ToList(),
            //     Measurments = user.Measurments.Select(meas => new MeasurmentViewModel
            //     {
            //         Id = meas.Id,
            //         Waistline = meas.Waistline,
            //         UserId = meas.UserId,
            //         Bicep = meas.Bicep,
            //         Calf = meas.Calf,
            //         Chest = meas.Chest,
            //         Gluteus = meas.Gluteus
            //     }).ToList()

            // }).FirstOrDefaultAsync();

            return null;
        }

        public Task<List<UserViewModel>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}