using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymApp.Models.Services.Infrastructure;
using GymApp.Models.ViewModels;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GymApp.Models.Services.Application
{
    public class UserService
    {
        private readonly IMongoCollection<UserViewModel> _usersCollection;

        public UserService(IOptions<AppDatabaseSettings> appDatabaseSettings)
        {
            MongoClient client = new MongoClient(appDatabaseSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(appDatabaseSettings.Value.DatabaseName);
            _usersCollection = database.GetCollection<UserViewModel>(appDatabaseSettings.Value.CollectionName);
        }

        public Task<UserViewModel> GetUser(string Id)
        {
            
           
            // var user = _usersCollection;
            // // list.Add(user);
            // // return list;
            return null;
        }

        public async Task<List<UserViewModel>> GetUsersAsync()
        {
            return await _usersCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}