namespace PremiumLibrary.Models.ViewModels
{
    public class RegistrationUser
    {
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class AuthorizationUser
    {
        public string UserNameOrEmailAddress { get; set; }
        public string Password { get; set; }
    }
}
