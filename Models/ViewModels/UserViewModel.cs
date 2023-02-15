using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Models.ViewModels;
using GymApp.Models.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GymApp.Models.ViewModels
{
	public class UserViewModel
	{
	
		public long Id{get;set;}
		public string? Name{get;set;}
		public string? Surname { get; set; }
		public string? Email { get; set; }
		public string? BirthDay { get; set; }
		public string? Username { get; set; }
		public string? Password { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Country { get; set; }
		public string? StateRegion { get; set; }
		public int? PlansCompleted{get;set;}	
		public string? ImagePath { get; set; }

		public List<PlanViewModel> Plans{get;set;}
		public List<MeasurmentViewModel> Measurments{get;set;}
		
	}
}