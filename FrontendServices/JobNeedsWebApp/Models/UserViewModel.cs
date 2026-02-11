namespace JobNeedsWebApp.Models
{
    public class UserViewModel
    {
        public long UserId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public IList<string> Roles { get; set; }

        public string Token { get; set; }

    }
}
