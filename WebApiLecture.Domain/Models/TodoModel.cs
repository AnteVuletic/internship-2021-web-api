using WebApiLecture.Data.Models.Entities;

namespace WebApiLecture.Domain.Models
{
    public class TodoModel
    {
        public string? Title { get; set; } = "";
        public string? Description { get; set; } = "";
    }

    public class TodoResponseModel : TodoModel
    {
        public int Id { get; set; }
    }

    public class TodoDetailResponseModel : TodoResponseModel
    {
        public IEnumerable<TodoItemResponseModel> TodoItems { get; set; } = new List<TodoItemResponseModel>();
    }

    public static class TodoModelExtensions
    {
        public static void MapToTodo(this TodoModel model, Todo todo, int userId)
        {
            todo.Title = model.Title;
            todo.Description = model.Description;
            todo.UserId = userId;
        }

        public static Todo ProjectToTodo(this TodoModel model, int userId)
        {
            return new Todo
            {
                Title = model.Title,
                Description = model.Description,
                UserId = userId
            };
        }

        public static TodoResponseModel ProjecToResponseModel(this Todo entity)
        {
            return new TodoResponseModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description
            };
        }

        public static IQueryable<TodoResponseModel> ProjectToResponseModel(this IQueryable<Todo> todoQueryable)
        {
            return todoQueryable
                .Select(todo => new TodoResponseModel
                {
                    Id = todo.Id,
                    Description = todo.Description,
                    Title = todo.Title
                });
        }

        public static IQueryable<TodoDetailResponseModel> ProjectToDetailResponse(this IQueryable<Todo> todoQueryable)
        {
            return todoQueryable
                .Select(todo => new TodoDetailResponseModel
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Description= todo.Description,
                    TodoItems = todo.Items.Select(item => new TodoItemResponseModel
                    {
                        Id = item.Id,
                        Description = item.Description,
                        IsDone = item.IsDone,
                    })
                });
        }
    }
}
