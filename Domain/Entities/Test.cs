
namespace Domain.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Question { get; set; }
        public List<UserTest> UserTest { get; set; }

    }
}
