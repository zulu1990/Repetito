using Repetito.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Repetito.Contracts.Authentication
{
    public class RegisterRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
        public string Subject { get; set; }

        public Sex Sex { get; set; }
        public City City { get; set; }
    }
       
}
