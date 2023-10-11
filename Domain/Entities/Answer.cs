
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(300)]
        public string Name { get; set; }
<<<<<<< HEAD
        public bool Status { get; set; }
        [ForeignKey("Question")]
=======
        public bool? Status { get; set; } = false;
>>>>>>> e4b72ca002f84a4861aa5d70c7c826175e876d89
        public int QuestionId  { get; set; }
        public Question Question  { get; set; }
    }
}
