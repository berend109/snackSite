using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using snackSite.Models;

namespace snackSite.Helper
{
	public class Session : Controller
	{
		public bool CheckIfLoggedIn(string? user)
		{
			return null != user;
		}

		public int CheckIfModerator(string? user)
		{
			if (!CheckIfLoggedIn(user)) return 0;
			if (user == null) return 0;
			var userObject = JsonConvert.DeserializeObject<Gebruiker>(user);
			if (userObject != null) return userObject.Adminrole = 1;
			return 0;
		}

		public int GetUserId(string? user) 
		{
			if (!CheckIfLoggedIn(user)) return 0;
			if (user == null) return 0;
			var userObject = JsonConvert.DeserializeObject<Gebruiker>(user);
			return userObject?.GebruikerId ?? 0;
		}
	}
}