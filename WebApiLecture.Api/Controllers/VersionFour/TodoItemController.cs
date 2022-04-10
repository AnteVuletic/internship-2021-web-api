using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiLecture.Domain.Models;
using WebApiLecture.Domain.Repositories.Interfaces;

namespace WebApiLecture.Api.Controllers.VersionFour
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemController(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todoItems = await _todoItemRepository.GetAllAsync();

            return Ok(todoItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todoItem = await _todoItemRepository.GetDetailByIdAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        [HttpPost("{todoId}")]
        public async Task<IActionResult> AddTodoItem(int todoId, TodoItemModel todoItem)
        {
            var isSuccessful = await _todoItemRepository.AddTodoItemAsync(todoId, todoItem);

            if (!isSuccessful)
            {
                return NotFound(todoId);
            }

            return Ok(todoItem);
        }

        [HttpPut("{todoItemId}")]
        public async Task<IActionResult> EditTodoItem(int todoItemId, TodoItemModel model)
        {
            var isSuccessful = await _todoItemRepository.EditTodoItemAsync(todoItemId, model);

            if (!isSuccessful)
            {
                return NotFound(todoItemId);
            }

            return Ok(model);
        }

        [HttpPatch("{todoItemId}/isDone/{isDone}")]
        public async Task<IActionResult> EditIsDone(int todoItemId, bool isDone)
        {
            var todoItem = await _todoItemRepository.EditIsDoneResponseAsync(todoItemId, isDone);

            if (todoItem == null)
            {
                return NotFound(todoItemId);
            }

            return Ok(todoItem);
        }

        [HttpDelete("{todoItemId}")]
        public async Task<IActionResult> DeleteTodoItem(int todoItemId)
        {
            var isSuccessful = await _todoItemRepository.DeleteTodoItemAsync(todoItemId);

            if (!isSuccessful)
            {
                return NotFound(todoItemId);
            }

            return Ok();
        }
    }
}
