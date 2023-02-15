using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Models.Services.Application;
using GymApp.Models.Services.Infrastructure;
using GymApp.Models.ViewModels;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GymApp.Models.Services.Application
{
    public class MongoUserService:IUserService
    {
        private readonly IMongoCollection<UserViewModel> _usersCollection;

        public MongoUserService(IOptions<AppDatabaseSettings> appDatabaseSettings)
        {
            MongoClient client = new MongoClient(appDatabaseSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(appDatabaseSettings.Value.DatabaseName);
            _usersCollection = database.GetCollection<UserViewModel>(appDatabaseSettings.Value.CollectionName);
        }

        public async Task<UserViewModel> GetUserAsync(string id)
        {
            var filter = Builders<UserViewModel>.Filter.Eq("Username", id);
            return await _usersCollection.Find(filter).Limit(1).SingleAsync();
        }

        public async Task<List<UserViewModel>> GetUsersAsync()
        {
            return await _usersCollection.Find(new BsonDocument()).ToListAsync();
        }

        
    }
}