using System.ComponentModel.DataAnnotations;

namespace ClaimsProcessingSample.Application.Requests.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}