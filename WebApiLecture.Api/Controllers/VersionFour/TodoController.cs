using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiLecture.Domain.Models;
using WebApiLecture.Domain.Repositories.Interfaces;

namespace WebApiLecture.Api.Controllers.VersionFour
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _todoRepository.GetAllResponseAsync();

            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _todoRepository.GetDetailByIdAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodoItem(TodoModel todo)
        {
            await _todoRepository.AddTodoAsync(todo);

            return Ok(todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTodoItem(int id, TodoModel todo)
        {
            var isSuccessful = await _todoRepository.EditTodoItemAsync(id, todo);

            if (!isSuccessful)
            {
                return NotFound(id);
            }

            return Ok(todo);
        }

        [HttpPatch("{id}/title/{title}")]
        public async Task<IActionResult> EditTodoTitle(int id, string title)
        {
            var todo = await _todoRepository.EditTodoDescriptionResponseAsync(id, title);

            if (todo == null)
            {
                return NotFound(id);
            }

            return Ok(todo);
        }

        [HttpPatch("{id}/description/{description}")]
        public async Task<IActionResult> EditTodoDescription(int id, string description)
        {
            var todo = await _todoRepository.EditTodoDescriptionResponseAsync(id, description);

            if (todo == null)
            {
                return NotFound(id);
            }

            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTodoItem(int id)
        {
            var isSuccessful = await _todoRepository.DeleteTodoItemAsync(id);

            if (!isSuccessful)
            {
                return NotFound(id);
            }

            return Ok();
        }
    }
}
