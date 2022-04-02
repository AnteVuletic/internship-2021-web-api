using WebApiLecture.Data.Models.Entities;

namespace WebApiLecture.Domain.Models
{
    public class TodoItemModel
    {
        public string? Description { get; set; } = "";
        public bool IsDone { get; set; }
    }

    public class TodoItemResponseModel : TodoItemModel
    {
        public int Id { get; set; }
    }

    public class TodoItemDetailResponseModel : TodoItemResponseModel
    {
        public TodoResponseModel Todo { get; set; } = new TodoResponseModel();
    }

    public static class TodoItemModelExtensions
    {
        public static void MapToTodoItem(this TodoItemModel model, TodoItem entity)
        {
            entity.Description = model.Description;
            entity.IsDone = model.IsDone;
        }

        public static TodoItem ProjectToTodoItem(this TodoItemModel model)
        {
            return new TodoItem
            {
                Description = model.Description,
                IsDone = model.IsDone
            };
        }

        public static TodoItemResponseModel ProjectToResponseModel(this TodoItem model)
        {
            return new TodoItemResponseModel
            {
                Id = model.Id,
                Description = model.Description,
                IsDone = model.IsDone
            };
        }

        public static IQueryable<TodoItemResponseModel> ProjectToResponseModel(this IQueryable<TodoItem> todoItemQueryable)
        {
            return todoItemQueryable
                .Select(todoItem => new TodoItemResponseModel
                {
                    Id = todoItem.Id,
                    Description = todoItem.Description,
                    IsDone = todoItem.IsDone
                });
        }

        public static IQueryable<TodoItemDetailResponseModel> ProjectToDetailResponseModel(this IQueryable<TodoItem> todoItemQueryable)
        {
            return todoItemQueryable
                .Select(todoItem => new TodoItemDetailResponseModel
                {
                    Id = todoItem.Id,
                    Description = todoItem.Description,
                    IsDone = todoItem.IsDone,
                    Todo = new TodoResponseModel
                    {
                        Id = todoItem.Todo.Id,
                        Description = todoItem.Todo.Description,
                        Title = todoItem.Todo.Title
                    }
                });
        }
    }
}
