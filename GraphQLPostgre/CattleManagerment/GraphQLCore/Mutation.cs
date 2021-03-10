using CattleManagerment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CattleManagerment
{
    public class Mutation
    {
		private List<User> Users = new List<User>
		{
			new User{
				Id = 1,
				FirstName = "Naveen",
				LastName = "Bommidi",
				Email = "naveen@gmail.com",
				Password="1234",
				PhoneNumber="8888899999"
			},
			new User{
				Id = 2,
				FirstName = "Hemanth",
				LastName = "Kumar",
				Email = "hemanth@gmail.com",
				Password = "abcd",
				PhoneNumber = "2222299999"
			}
		};

		public string UserLogin(LoginInput login)
		{
			var currentUser = Users.Where(u => u.Email.ToLower() == login.Email &&
			u.Password == login.Password).FirstOrDefault();

			if (currentUser != null)
			{
				return "for now i'm dummy jwt access token";
			}
			return string.Empty;
		}
	}
}
