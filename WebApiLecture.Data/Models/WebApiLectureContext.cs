using Microsoft.EntityFrameworkCore;
using WebApiLecture.Data.Models.Entities;

namespace WebApiLecture.Data.Models
{
    public class WebApiLectureContext : DbContext
    {
        public WebApiLectureContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
