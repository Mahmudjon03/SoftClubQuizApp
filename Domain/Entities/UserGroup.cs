using System.Reflection.Metadata.Ecma335;

namespace Domain
{
    public class UserGroup 
    {
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public virtual User User  { get; set; }
        public virtual Group Group { get; set; }
    }
}