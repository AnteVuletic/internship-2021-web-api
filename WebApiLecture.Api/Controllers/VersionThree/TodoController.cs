using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiLecture.Domain.Models;
using WebApiLecture.Domain.Repositories.Interfaces;

namespace WebApiLecture.Api.Controllers.VersionThree
{
    [ApiController]
    [Route("v3/[controller]")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var todos = _todoRepository.GetAllResponse();

            return Ok(todos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _todoRepository.GetDetailById(id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPost]
        public IActionResult AddTodoItem(TodoModel todo)
        {
            _todoRepository.AddTodo(todo);

            return Ok(todo);
        }

        [HttpPut("{id}")]
        public IActionResult EditTodoItem(int id, TodoModel todo)
        {
            var isSuccessful = _todoRepository.EditTodoItem(id, todo);

            if (!isSuccessful)
            {
                return NotFound(id);
            }

            return Ok(todo);
        }

        [HttpPatch("{id}/title/{title}")]
        public IActionResult EditTodoTitle(int id, string title)
        {
            var todo = _todoRepository.EditTodoDescriptionResponse(id, title);

            if (todo == null)
            {
                return NotFound(id);
            }

            return Ok(todo);
        }

        [HttpPatch("{id}/description/{description}")]
        public IActionResult EditTodoDescription(int id, string description)
        {
            var todo = _todoRepository.EditTodoDescriptionResponse(id, description);

            if (todo == null)
            {
                return NotFound(id);
            }

            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveTodoItem(int id)
        {
            var isSuccessful = _todoRepository.DeleteTodoItem(id);

            if (!isSuccessful)
            {
                return NotFound(id);
            }

            return Ok();
        }
    }
}
