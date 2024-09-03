using System.ComponentModel.DataAnnotations;

namespace Tournament.Api.Requests
{
    public class RegisterUserRequest
    {
        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
