using WebApiLecture.Data.Models.Entities;
using WebApiLecture.Domain.Models;

namespace WebApiLecture.Domain.Repositories.Interfaces
{
    public interface ITodoItemRepository
    {
        List<TodoItem> GetAll();
        List<TodoItemResponseModel> GetAllResponse();
        Task<List<TodoItemResponseModel>> GetAllAsync();

        TodoItem GetById(int id);
        TodoItemDetailResponseModel GetDetailById(int id);
        Task<TodoItemDetailResponseModel> GetDetailByIdAsync(int id);

        bool AddTodoItem(int todoId, TodoItem model);
        bool AddTodoItem(int todoId, TodoItemModel model);
        Task<bool> AddTodoItemAsync(int todoId, TodoItemModel model);

        bool EditTodoItem(int todoItemId, TodoItem model);
        bool EditTodoItem(int todoItemId, TodoItemModel model);
        Task<bool> EditTodoItemAsync(int todoItemId, TodoItemModel model);

        TodoItem EditIsDone(int todoItemId, bool isDone);
        TodoItemResponseModel EditIsDoneResponse(int todoItemId, bool isDone);
        Task<TodoItemResponseModel> EditIsDoneResponseAsync(int todoItemId, bool isDone);

        bool DeleteTodoItem(int todoItemId);
        Task<bool> DeleteTodoItemAsync(int todoItemId);
    }
}
