using Microsoft.EntityFrameworkCore;
using WebApiLecture.Data.Models;
using WebApiLecture.Data.Models.Entities;
using WebApiLecture.Domain.Models;
using WebApiLecture.Domain.Repositories.Interfaces;

namespace WebApiLecture.Domain.Repositories.Implementations
{
    public class TodoRepository : ITodoRepository
    {
        private readonly WebApiLectureContext _webApiLectureContext;

        public TodoRepository(WebApiLectureContext webApiLectureContext)
        {
            _webApiLectureContext = webApiLectureContext;
        }

        public void AddTodo(Todo model)
        {
            _webApiLectureContext.Todos.Add(model);
            _webApiLectureContext.SaveChanges();
        }

        public void AddTodo(TodoModel model)
        {
            var todo = model.ProjectToTodo();
            _webApiLectureContext.Todos.Add(todo);
            _webApiLectureContext.SaveChanges();
        }

        public async Task AddTodoAsync(TodoModel model)
        {
            var todo = model.ProjectToTodo();
            await _webApiLectureContext.Todos.AddAsync(todo);
            await _webApiLectureContext.SaveChangesAsync();
        }

        public bool DeleteTodoItem(int id)
        {
            var todo = _webApiLectureContext.Todos.Find(id);

            if (todo == null)
            {
                return false;
            }

            _webApiLectureContext.Todos.Remove(todo);
            _webApiLectureContext.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteTodoItemAsync(int id)
        {
            var todo = await _webApiLectureContext.Todos.FindAsync(id);

            if (todo == null)
            {
                return false;
            }

            _webApiLectureContext.Todos.Remove(todo);
            await _webApiLectureContext.SaveChangesAsync();

            return true;
        }

        public Todo EditTodoDescription(int id, string description)
        {
            var todo = _webApiLectureContext.Todos.Find(id);

            if (todo == null)
            {
                return null;
            }

            todo.Description = description;
            _webApiLectureContext.SaveChanges();

            return todo;
        }

        public TodoResponseModel EditTodoDescriptionResponse(int id, string description)
        {
            var todo = _webApiLectureContext.Todos.Find(id);

            if (todo == null)
            {
                return null;
            }

            todo.Description = description;
            _webApiLectureContext.SaveChanges();

            return todo.ProjecToResponseModel();
        }

        public async Task<TodoResponseModel> EditTodoDescriptionResponseAsync(int id, string description)
        {
            var todo = await _webApiLectureContext.Todos.FindAsync(id);

            if (todo == null)
            {
                return null;
            }

            todo.Description = description;
            await _webApiLectureContext.SaveChangesAsync();

            return todo.ProjecToResponseModel();
        }

        public bool EditTodoItem(int id, Todo model)
        {
            var todo = _webApiLectureContext.Todos.Find(id);

            if (todo == null)
            {
                return false;
            }

            todo.Title = model.Title;
            todo.Description = model.Description;

            _webApiLectureContext.SaveChanges();

            return true;
        }

        public bool EditTodoItem(int id, TodoModel model)
        {
            var todo = _webApiLectureContext
                .Todos
                .Find(id);

            if (todo == null)
            {
                return false;
            }

            model.MapToTodo(todo);
            _webApiLectureContext.SaveChanges();

            return true;
        }

        public async Task<bool> EditTodoItemAsync(int id, TodoModel model)
        {
            var todo = await _webApiLectureContext
                .Todos
                .FindAsync(id);

            if (todo == null)
            {
                return false;
            }

            model.MapToTodo(todo);
            await _webApiLectureContext.SaveChangesAsync();

            return true;
        }

        public Todo EditTodoTitle(int id, string title)
        {
            var todo = _webApiLectureContext.Todos.Find(id);

            if (todo == null)
            {
                return null;
            }

            todo.Title = title;
            _webApiLectureContext.SaveChanges();

            return todo;
        }

        public TodoResponseModel EditTodoTitleResponse(int id, string title)
        {
            var todo = _webApiLectureContext.Todos.Find(id);

            if (todo == null)
            {
                return null;
            }

            todo.Title = title;
            _webApiLectureContext.SaveChanges();

            return todo.ProjecToResponseModel();
        }

        public async Task<TodoResponseModel> EditTodoTitleResponseAsync(int id, string title)
        {
            var todo = await _webApiLectureContext.Todos.FindAsync(id);

            if (todo == null)
            {
                return null;
            }

            todo.Title = title;
            await _webApiLectureContext.SaveChangesAsync();

            return todo.ProjecToResponseModel();
        }

        public List<Todo> GetAll()
        {
            var todos = _webApiLectureContext
                .Todos
                .ToList();

            return todos;
        }

        public List<TodoResponseModel> GetAllResponse()
        {
            var todoModels = _webApiLectureContext
                .Todos
                .ProjectToResponseModel()
                .ToList();

            return todoModels;
        }

        public async Task<List<TodoResponseModel>> GetAllResponseAsync()
        {
            var todoModels = await _webApiLectureContext
                .Todos
                .ProjectToResponseModel()
                .ToListAsync();

            return todoModels;
        }

        public Todo GetById(int id)
        {
            var todo = _webApiLectureContext
                .Todos
                .Include(todo => todo.Items)
                .FirstOrDefault(todo => todo.Id == id);

            if (todo == null)
            {
                return null;
            }

            foreach (var todoItem in todo.Items)
            {
                todoItem.Todo = null;
            }

            return todo;
        }

        public TodoDetailResponseModel GetDetailById(int id)
        {
            var todoDetail = _webApiLectureContext
                .Todos
                .ProjectToDetailResponse()
                .FirstOrDefault(todo => todo.Id == id);

            if (todoDetail == null)
            {
                return null;
            }

            return todoDetail;
        }

        public async Task<TodoDetailResponseModel> GetDetailByIdAsync(int id)
        {
            var todoDetail = await _webApiLectureContext
                .Todos
                .ProjectToDetailResponse()
                .FirstOrDefaultAsync(todo => todo.Id == id);

            if (todoDetail == null)
            {
                return null;
            }

            return todoDetail;
        }
    }
}
