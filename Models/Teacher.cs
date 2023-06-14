using System.ComponentModel.DataAnnotations;

namespace CoreCrudOperation.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string Name { get; set; }
        public string Subject { get; set; }
    }
}
