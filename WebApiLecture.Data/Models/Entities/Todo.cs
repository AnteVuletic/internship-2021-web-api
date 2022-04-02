namespace WebApiLecture.Data.Models.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ICollection<TodoItem> Items { get; set; } = new List<TodoItem>();
    }
}
