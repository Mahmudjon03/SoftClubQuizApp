using Domain.Enums;

namespace Domain.DTOs.UserDto

{
    public class BaseUserDto
    {
        public int Id { get; set; }
       
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
       
        public string Phone { get; set; }
       
        public string Email { get; set; }

        public string Password { get; set; }
      
        public string Login { get; set; }
        public Status Active { get; set; }
       
    }
}
