using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymApp.Models.ViewModels;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using GymApp.Models.Services.Infrastructure;

namespace GymApp.Models.Services.Application
{
    public abstract class AbstractUserService
    {
        private readonly IMongoCollection<UserViewModel> _usersCollection;

        public AbstractUserService(IOptions<AppDatabaseSettings> appDatabaseSettings)
        {
            var mongoClient = new MongoClient(appDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(appDatabaseSettings.Value.DatabaseName);
            _usersCollection = mongoDatabase.GetCollection<UserViewModel>(
            "Users");
        }

         public abstract UserViewModel GetUsers();
         public abstract UserViewModel GetUser(string Id);


        
    }
}