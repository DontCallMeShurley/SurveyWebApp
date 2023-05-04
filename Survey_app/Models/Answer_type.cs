using System.ComponentModel.DataAnnotations;

namespace Survey_app.Models
{
    public class AnswerType
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(50)]
        public string Type { get; set; }



    }
}
