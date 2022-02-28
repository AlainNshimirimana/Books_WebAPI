using System.ComponentModel.DataAnnotations;
namespace Books_WebAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string bookTitle { get; set; } = string.Empty;
    }
}
