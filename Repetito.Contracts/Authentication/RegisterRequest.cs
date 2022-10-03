using System.ComponentModel.DataAnnotations;

namespace Repetito.Contracts.Authentication
{
    public class RegisterRequest
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;


        [EmailAddress]
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
       
}
