using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiLecture.Data.Models;
using WebApiLecture.Data.Models.Entities;

namespace WebApiLecture.Api.Controllers.VersionOne
{
    [ApiController]
    [Route("v1/[controller]")]
    [Authorize]
    public class TodoItemController : ControllerBase
    {
        private readonly WebApiLectureContext _webApiLectureContext;

        public TodoItemController(WebApiLectureContext webApiLectureContext)
        {
            _webApiLectureContext = webApiLectureContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var todoItems = _webApiLectureContext
                .TodoItems
                .ToList();

            return Ok(todoItems);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todoItem = _webApiLectureContext
                .TodoItems
                .Include(todoItems => todoItems.Todo)
                .FirstOrDefault(todoItem => todoItem.Id == id);

            if (todoItem == null)
            {
                return NotFound();
            }

            if (todoItem.Todo != null)
            {
                todoItem.Todo.Items = new List<TodoItem>();
            }

            return Ok(todoItem);
        }

        [HttpPost("{todoId}")]
        public IActionResult AddTodoItem(int todoId, TodoItem todoItem)
        {
            var todo = _webApiLectureContext
                .Todos
                .Find(todoId);

            if (todo == null)
            {
                return NotFound();
            }

            todoItem.TodoId = todoId;
            _webApiLectureContext.TodoItems.Add(todoItem);
            _webApiLectureContext.SaveChanges();

            todoItem.Todo = null;

            return Ok(todoItem);
        }

        [HttpPut("{todoItemId}")]
        public IActionResult EditTodoItem(int todoItemId, TodoItem model)
        {
            var todoItem = _webApiLectureContext
                .TodoItems
                .Find(todoItemId);

            if (todoItem == null)
            {
                return NotFound(todoItemId);
            }

            todoItem.Description = model.Description;
            todoItem.IsDone = model.IsDone;
            _webApiLectureContext.SaveChanges();

            todoItem.Todo = null;

            return Ok(todoItem);
        }

        [HttpPatch("{todoItemId}/isDone/{isDone}")]
        public IActionResult EditIsDone(int todoItemId, bool isDone)
        {
            var todoItem = _webApiLectureContext
                .TodoItems
                .Find(todoItemId);

            if (todoItem == null)
            {
                return NotFound(todoItemId);
            }

            todoItem.IsDone = isDone;
            _webApiLectureContext.SaveChanges();

            return Ok(todoItem);
        }

        [HttpDelete("{todoItemId}")]
        public IActionResult DeleteTodoItem(int todoItemId)
        {
            var todoItem = _webApiLectureContext
                .TodoItems
                .Find(todoItemId);

            if (todoItem == null)
            {
                return NotFound(todoItemId);
            }

            _webApiLectureContext.TodoItems.Remove(todoItem);
            _webApiLectureContext.SaveChanges();

            return Ok();
        }
    }
}
