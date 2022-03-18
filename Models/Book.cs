using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books_WebAPI.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string bookTitle { get; set; } = string.Empty;
    }
}
