using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GymApp.Models.ViewModels
{
	public class UserViewModel
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id{get;set;}
		[BsonElement("Name")]
		public string? Name{get;set;}
		[BsonElement("Surname")]
		public string? Surname { get; set; }
		[BsonElement("Email")]
		public string? Email { get; set; }
		[BsonElement("BirthDay")]
		public DateTime BirthDay { get; set; }
		[BsonElement("Username")]
		public string? Username { get; set; }
		[BsonElement("Password")]
		public string? Password { get; set; }
		[BsonElement("PhoneNumber")]
		public string? PhoneNumber { get; set; }
		[BsonElement("Country")]
		public string? Country { get; set; }
		[BsonElement("StateRegion")]
		public string? StateRegion { get; set; }
		[BsonElement("PlansCompleted")]
		public int PlansCompleted{get;set;}	
		[BsonElement("ImagePath")]
		public string? ImagePath { get; set; }
		
	}
}