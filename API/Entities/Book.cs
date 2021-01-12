using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string AuthorName { get; set; }
        public int Status  { get; set; }
    }
}