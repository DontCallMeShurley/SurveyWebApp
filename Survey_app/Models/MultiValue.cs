using System.ComponentModel.DataAnnotations;

namespace Survey_app.Models
{
    public class MultiValue
    {
        [Key]
        public int Id { get; set; }
        public int MultiAnswerId { get; set; }
        public virtual MultiAnswer MultiAnswer { get; set; }
        public string Value { get; set; } = null!;
    }
}
