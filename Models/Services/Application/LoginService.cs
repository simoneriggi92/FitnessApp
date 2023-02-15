using FitnessApp.Models.Services.Infrastructure;
using GymApp.Models.Services.Infrastructure;
using GymApp.Models.ViewModels;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FitnessApp.Models.Services.Application
{
    public class LoginService : ILoginService
    {

        private readonly IMongoCollection<UserViewModel> _usersCollection;

        public LoginService(IOptions<AppDatabaseSettings> appDatabaseSettings)
        {
            MongoClient client = new MongoClient(appDatabaseSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(appDatabaseSettings.Value.DatabaseName);
            _usersCollection = database.GetCollection<UserViewModel>(appDatabaseSettings.Value.CollectionName);   
        }
        public async Task<UserViewModel> AutenticateUser(string username, string password)
        {
            var filter = Builders<UserViewModel>.Filter.Eq("Username", username) & Builders<UserViewModel>.Filter.Eq("Password", password);
            return await _usersCollection.Find(filter).Limit(1).SingleAsync();
        }

    }
}