using Microsoft.EntityFrameworkCore;
using WebApiLecture.Data.Models;
using WebApiLecture.Data.Models.Entities;
using WebApiLecture.Domain.Models;
using WebApiLecture.Domain.Repositories.Interfaces;

namespace WebApiLecture.Domain.Repositories.Implementations
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly WebApiLectureContext _webApiLectureContext;

        public TodoItemRepository(WebApiLectureContext webApiLectureContext)
        {
            _webApiLectureContext = webApiLectureContext;
        }

        public bool AddTodoItem(int todoId, TodoItem todoItem)
        {
            var todo = _webApiLectureContext
                .Todos
                .Find(todoId);

            if (todo == null)
            {
                return false;
            }

            todoItem.TodoId = todoId;
            _webApiLectureContext.TodoItems.Add(todoItem);
            _webApiLectureContext.SaveChanges();

            todoItem.Todo = null;

            return true;
        }

        public bool AddTodoItem(int todoId, TodoItemModel model)
        {
            var todo = _webApiLectureContext
                .Todos
                .Find(todoId);

            if (todo == null)
            {
                return false;
            }

            var todoItem = model.ProjectToTodoItem();
            todoItem.TodoId = todoId;
            _webApiLectureContext.TodoItems.Add(todoItem);
            _webApiLectureContext.SaveChanges();

            return true;
        }

        public async Task<bool> AddTodoItemAsync(int todoId, TodoItemModel model)
        {
            var todo = await _webApiLectureContext
                .Todos
                .FindAsync(todoId);

            if (todo == null)
            {
                return false;
            }

            var todoItem = model.ProjectToTodoItem();
            todoItem.TodoId = todoId;
            await _webApiLectureContext.TodoItems.AddAsync(todoItem);
            await _webApiLectureContext.SaveChangesAsync();

            return true;
        }

        public bool DeleteTodoItem(int todoItemId)
        {
            var todoItem = _webApiLectureContext
                .TodoItems
                .Find(todoItemId);

            if (todoItem == null)
            {
                return false;
            }

            _webApiLectureContext.TodoItems.Remove(todoItem);
            _webApiLectureContext.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteTodoItemAsync(int todoItemId)
        {
            var todoItem = await _webApiLectureContext
                .TodoItems
                .FindAsync(todoItemId);

            if (todoItem == null)
            {
                return false;
            }

            _webApiLectureContext.TodoItems.Remove(todoItem);
            await _webApiLectureContext.SaveChangesAsync();

            return true;
        }

        public TodoItem EditIsDone(int todoItemId, bool isDone)
        {
            var todoItem = _webApiLectureContext
                .TodoItems
                .Find(todoItemId);

            if (todoItem == null)
            {
                return null;
            }

            todoItem.IsDone = isDone;
            _webApiLectureContext.SaveChanges();

            return todoItem;
        }

        public TodoItemResponseModel EditIsDoneResponse(int todoItemId, bool isDone)
        {
            var todoItem = _webApiLectureContext
                .TodoItems
                .Find(todoItemId);

            if (todoItem == null)
            {
                return null;
            }

            todoItem.IsDone = isDone;
            _webApiLectureContext.SaveChanges();

            return todoItem.ProjectToResponseModel();
        }

        public async Task<TodoItemResponseModel> EditIsDoneResponseAsync(int todoItemId, bool isDone)
        {
            var todoItem = await _webApiLectureContext
                .TodoItems
                .FindAsync(todoItemId);

            if (todoItem == null)
            {
                return null;
            }

            todoItem.IsDone = isDone;
            await _webApiLectureContext.SaveChangesAsync();

            return todoItem.ProjectToResponseModel();
        }

        public bool EditTodoItem(int todoItemId, TodoItem model)
        {
            var todoItem = _webApiLectureContext
                .TodoItems
                .Find(todoItemId);

            if (todoItem == null)
            {
                return false;
            }

            todoItem.Description = model.Description;
            todoItem.IsDone = model.IsDone;
            _webApiLectureContext.SaveChanges();

            return true;
        }

        public bool EditTodoItem(int todoItemId, TodoItemModel model)
        {
            var todoItem = _webApiLectureContext
                .TodoItems
                .Find(todoItemId);

            if (todoItem == null)
            {
                return false;
            }

            model.MapToTodoItem(todoItem);
            _webApiLectureContext.SaveChanges();

            return true;
        }

        public async Task<bool> EditTodoItemAsync(int todoItemId, TodoItemModel model)
        {
            var todoItem = await _webApiLectureContext
                .TodoItems
                .FindAsync(todoItemId);

            if (todoItem == null)
            {
                return false;
            }

            model.MapToTodoItem(todoItem);
            await _webApiLectureContext.SaveChangesAsync();

            return true;
        }

        public List<TodoItem> GetAll()
        {
            var todoItems = _webApiLectureContext
                .TodoItems
                .ToList();

            return todoItems;
        }

        public async Task<List<TodoItemResponseModel>> GetAllAsync()
        {
            var todoItemModels = await _webApiLectureContext
                .TodoItems
                .ProjectToResponseModel()
                .ToListAsync();

            return todoItemModels;
        }

        public List<TodoItemResponseModel> GetAllResponse()
        {
            var todoItemModels = _webApiLectureContext
                .TodoItems
                .ProjectToResponseModel()
                .ToList();

            return todoItemModels;
        }

        public TodoItem GetById(int id)
        {
            var todoItem = _webApiLectureContext
                .TodoItems
                .Include(todoItems => todoItems.Todo)
                .FirstOrDefault(todoItem => todoItem.Id == id);

            if (todoItem == null)
            {
                return null;
            }

            if (todoItem.Todo != null)
            {
                todoItem.Todo.Items = new List<TodoItem>();
            }

            return todoItem;
        }

        public TodoItemDetailResponseModel GetDetailById(int id)
        {
            var todoDetail = _webApiLectureContext
                .TodoItems
                .ProjectToDetailResponseModel()
                .FirstOrDefault(todoItem => todoItem.Id == id);

            if (todoDetail == null)
            {
                return null;
            }

            return todoDetail;
        }

        public async Task<TodoItemDetailResponseModel> GetDetailByIdAsync(int id)
        {
            var todoDetail = await _webApiLectureContext
                .TodoItems
                .ProjectToDetailResponseModel()
                .FirstOrDefaultAsync(todoItem => todoItem.Id == id);

            if (todoDetail == null)
            {
                return null;
            }

            return todoDetail;
        }
    }
}
