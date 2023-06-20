using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using snackSite.Models;

namespace snackSite.Helpers
{
	public class Session : Controller
	{
		public bool CheckIfLoggedIn(string? user)
		{
			return null != user;
		}
		
		public static bool LoggedIn(string? user)
		{
			return null != user;
		}

		public int GetUserId(string? user) 
		{
			if (!CheckIfLoggedIn(user)) return 0;
			if (user == null) return 0;
			var userObject = JsonConvert.DeserializeObject<Gebruiker>(user);
			return userObject?.GebruikerId ?? 0;
		}
		
		public bool CheckAdmin(string? user)
		{
			if (!CheckIfLoggedIn(user)) return false;
			if (user == null) return false;
			var userObject = JsonConvert.DeserializeObject<Gebruiker>(user);
			return userObject?.Adminrole == true;
		}
	}
}