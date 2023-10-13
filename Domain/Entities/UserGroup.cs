
using System.Reflection.Metadata.Ecma335;

namespace Domain.Entities
{
    public class UserGroup 
    {
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
    }
}
