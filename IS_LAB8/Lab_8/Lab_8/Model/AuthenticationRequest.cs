using System.ComponentModel.DataAnnotations;

namespace Lab_8.Model
{
    public class AuthenticationRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}