using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymApp.Models.ViewModels;

namespace GymApp.Models.Services.Application
{
    public class UserService
    {
        
        public UserViewModel GetServices()
        {
            var list = new List<UserViewModel>();
            var user = new UserViewModel()
            {
                Id = 10,
                Name="Simone",
                Surname = "Riggi",
                Email = "simone.riggi92@gmail.com",
                Username = "Simo92",
                Password ="1234",
                BithDay = DateTime.Parse("14 Oct 1992"),
                PhoneNumber="+393202795763",
                Country="Italy",
                StateRegion="San Cataldo",
                PlansCompleted= 12,
                ImagePath = "/profile.jpeg"
            };
            // list.Add(user);
            // return list;
            return user;
        }
    }
}