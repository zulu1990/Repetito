using Repetito.Domain.Enums;

namespace Repetito.Domain.Entities
{
    public class Teacher : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Sex Sex { get; set; }
        public City City { get; set; }
        public string Subject { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<Pupil> Pupils { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
