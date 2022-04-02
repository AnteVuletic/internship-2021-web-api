namespace WebApiLecture.Data.Models.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool IsDone { get; set; }

        public int TodoId { get; set; }
        public Todo? Todo { get; set; }
    }
}
