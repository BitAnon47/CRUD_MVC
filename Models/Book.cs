using System.ComponentModel.DataAnnotations;

namespace MyMvcApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please enter an author.")]
        public string ?Author { get; set; }

    }
}
