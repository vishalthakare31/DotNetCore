using System.ComponentModel.DataAnnotations;

namespace CoreCrudOperation.Models
{
    public class ContactForm
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a message.")]
        public string Message { get; set; }
    }
}