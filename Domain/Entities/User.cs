namespace Domain
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
            
        public string Password { get; set; }=null!;
        [MaxLength(50)]
        public UserType UserType { get; set; } = UserType.User;
        public Status Active { get; set; }
        public virtual List<StudentTest>? StudentTests { get; set; }=null;
        public virtual List<Test> MentorTests { get; set; }
        public virtual List<UserGroup> UserGroup { get; set; }= new List<UserGroup>();
     }
}

