using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using snackSite.Models;

namespace snackSite.Helper;

public class Session : Controller
{
    public bool CheckIfLoggedIn(string? user)
    {
        return null != user;
    }

    public int CheckIfAuthorized(string? user)
    {
        if (!CheckIfLoggedIn(user)) return 0;
        if (user == null) return 0; // this is for safety just in case
        var userObject = JsonConvert.DeserializeObject<User>(user);
        return userObject.IsAdmin = 0;
    }

    public int CheckIfAdmin(string? user)
    {
        if (!CheckIfLoggedIn(user)) return 0;
        if (user == null) return 0; // this is for safety just in case
        var userObject = JsonConvert.DeserializeObject<User>(user);
        return userObject.IsAdmin = 1;
    }
}