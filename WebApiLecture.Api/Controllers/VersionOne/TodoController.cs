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
    public class TodoController : ControllerBase
    {
        private readonly WebApiLectureContext _webApiLectureContext;

        public TodoController(WebApiLectureContext webApilectureContext)
        {
            _webApiLectureContext = webApilectureContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var todos = _webApiLectureContext
                .Todos
                .ToList();

            return Ok(todos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _webApiLectureContext
                .Todos
                .Include(todo => todo.Items)
                .FirstOrDefault(todo => todo.Id == id);

            if (todo == null)
            {
                return NotFound();
            }
            
            foreach (var todoItem in todo.Items)
            {
                todoItem.Todo = null;
            }

            return Ok(todo);
        }

        [HttpPost]
        public IActionResult AddTodoItem(Todo todo)
        {
            _webApiLectureContext.Todos.Add(todo);
            _webApiLectureContext.SaveChanges();

            return Ok(todo.Id);
        }

        [HttpPut("{id}")]
        public IActionResult EditTodoItem(int id, Todo todoEdited)
        {
            var todo = _webApiLectureContext.Todos.Find(id);

            if (todo == null)
            {
                return NotFound(id);
            }

            todo.Title = todoEdited.Title;
            todo.Description = todoEdited.Description;

            _webApiLectureContext.SaveChanges();

            return Ok(todo);
        }

        [HttpPatch("{id}/title/{title}")]
        public IActionResult EditTodoTitle(int id, string title)
        {
            var todo = _webApiLectureContext.Todos.Find(id);

            if (todo == null)
            {
                return NotFound(id);
            }

            todo.Title = title;
            _webApiLectureContext.SaveChanges();

            return Ok(todo);
        }

        [HttpPatch("{id}/description/{description}")]
        public IActionResult EditTodoDescription(int id, string description)
        {
            var todo = _webApiLectureContext.Todos.Find(id);

            if (todo == null)
            {
                return NotFound(id);
            }

            todo.Description = description;
            _webApiLectureContext.SaveChanges();

            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveTodoItem(int id)
        {
            var todo = _webApiLectureContext.Todos.Find(id);

            if (todo == null)
            {
                return NotFound(id);
            }

            _webApiLectureContext.Todos.Remove(todo);
            _webApiLectureContext.SaveChanges();

            return Ok();
        }
    }
}
