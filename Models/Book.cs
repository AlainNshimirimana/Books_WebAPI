using System.ComponentModel.DataAnnotations;
namespace Books_WebAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string bookTitle { get; set; }
    }
}
