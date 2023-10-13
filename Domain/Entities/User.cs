using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(50)]
        public UserType UserType { get; set; } = UserType.User;
        public Status Active { get; set; }
        public List<UserTest> UserTest { get; set; } = new List<UserTest>();
        public List<UserGroup> UserGroup { get; set; }= new List<UserGroup>();
     }
}
