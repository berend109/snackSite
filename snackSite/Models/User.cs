namespace snackSite.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Password2 { get; set; }
        public bool IsAdmin { get; set; }
    }
}