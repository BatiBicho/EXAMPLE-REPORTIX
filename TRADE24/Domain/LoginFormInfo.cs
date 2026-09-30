namespace TRADE24.Domain
{
    public class LoginFormVM
    {
        public string? Usuario { get; set; }
        public string? Password { get; set; }
    }

    public class ForgotPasswordVM
    {
        public string? UserId { get; set; }
    }
}
