using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Models.ViewModels
{
	public class UserViewModel
	{
		public int Id{get;set;}
		public string? Name{get;set;}
		public string? Surname { get; set; }
		public DateTime BithDay { get; set; }
		public string? Username { get; set; }
		public string? Password { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Country { get; set; }
		public string? StateRegion { get; set; }

		public int PlansCompleted{get;set;}	

		public string? ImagePath { get; set; }
		
	}
}