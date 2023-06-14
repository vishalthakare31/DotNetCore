using System.ComponentModel.DataAnnotations;
namespace CoreCrudOperation.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
       
        public string name { get; set; }
        [Required]
        public string dept { get; set; }

    }
}
