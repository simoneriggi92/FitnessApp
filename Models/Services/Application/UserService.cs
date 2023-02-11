using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymApp.Models.Services.Infrastructure;
using GymApp.Models.ViewModels;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GymApp.Models.Services.Application
{
    public class UserService: AbstractUserService
    {
        
        private readonly IMongoCollection<UserViewModel> _users;
        public UserService(IOptions<AppDatabaseSettings> appDatabaseSettings):base(appDatabaseSettings)
        {
            MongoClient client = new MongoClient(appDatabaseSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(appDatabaseSettings.Value.DatabaseName);
            _users = database.GetCollection<UserViewModel>(appDatabaseSettings.Value.CollectionName);
        }
        public override UserViewModel GetUser(string Id)
        {
            // var list = new List<UserViewModel>();
            // var user = new UserViewModel()
            // {
            //     Id = 10,
            //     Name="Simone",
            //     Surname = "Riggi",
            //     Email = "simone.riggi92@gmail.com",
            //     Username = "Simo92",
            //     Password ="1234",
            //     BirthDay = DateTime.Parse("14 Oct 1992"),
            //     PhoneNumber="+393202795763",
            //     Country="Italy",
            //     StateRegion="San Cataldo",
            //     PlansCompleted= 12,
            //     ImagePath = "/profile.jpeg"
            // };
            var user = _usersCollection;
            // list.Add(user);
            // return list;
            return user;
        }

        public async override Task<List<UserViewModel>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}