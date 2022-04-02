using WebApiLecture.Data.Models.Entities;
using WebApiLecture.Domain.Models;

namespace WebApiLecture.Domain.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        List<Todo> GetAll();
        List<TodoResponseModel> GetAllResponse();
        Task<List<TodoResponseModel>> GetAllResponseAsync();

        Todo GetById(int id);
        TodoDetailResponseModel GetDetailById(int id);
        Task<TodoDetailResponseModel> GetDetailByIdAsync(int id);

        void AddTodo(Todo model);
        void AddTodo(TodoModel model);
        Task AddTodoAsync(TodoModel model);

        bool EditTodoItem(int id, Todo model);
        bool EditTodoItem(int id, TodoModel model);
        Task<bool> EditTodoItemAsync(int id, TodoModel model);

        Todo EditTodoTitle(int id, string title);
        TodoResponseModel EditTodoTitleResponse(int id, string title);
        Task<TodoResponseModel> EditTodoTitleResponseAsync(int id, string title);

        Todo EditTodoDescription(int id, string description);
        TodoResponseModel EditTodoDescriptionResponse(int id, string description);
        Task<TodoResponseModel> EditTodoDescriptionResponseAsync(int id, string description);

        bool DeleteTodoItem(int id);
        Task<bool> DeleteTodoItemAsync(int id);
    }
}
