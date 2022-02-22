using Books_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Books_WebAPI.Controllers
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=NIGHTWALKER\SQLEXPRESS;Initial Catalog=Book_DB;Integrated Security=True;Pooling=False");
        }
    }
}
