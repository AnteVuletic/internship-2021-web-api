using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiLecture.Data.Models.Entities;
using WebApiLecture.Domain.Repositories.Interfaces;

namespace WebApiLecture.Api.Controllers.VersionTwo
{
    [ApiController]
    [Route("v2/[controller]")]
    [Authorize]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemController(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var todoItems = _todoItemRepository.GetAll();

            return Ok(todoItems);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todoItem = _todoItemRepository.GetById(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        [HttpPost("{todoId}")]
        public IActionResult AddTodoItem(int todoId, TodoItem todoItem)
        {
            var isSuccessful = _todoItemRepository.AddTodoItem(todoId, todoItem);

            if (!isSuccessful)
            {
                return NotFound(todoId);
            }

            return Ok(todoItem);
        }

        [HttpPut("{todoItemId}")]
        public IActionResult EditTodoItem(int todoItemId, TodoItem model)
        {
            var isSuccessful = _todoItemRepository.EditTodoItem(todoItemId, model);

            if (!isSuccessful)
            {
                return NotFound(todoItemId);
            }

            return Ok(model);
        }

        [HttpPatch("{todoItemId}/isDone/{isDone}")]
        public IActionResult EditIsDone(int todoItemId, bool isDone)
        {
            var todoItem = _todoItemRepository.EditIsDone(todoItemId, isDone);

            if (todoItem == null)
            {
                return NotFound(todoItemId);
            }

            return Ok(todoItem);
        }

        [HttpDelete("{todoItemId}")]
        public IActionResult DeleteTodoItem(int todoItemId)
        {
            var isSuccessful = _todoItemRepository.DeleteTodoItem(todoItemId);

            if (!isSuccessful)
            {
                return NotFound(todoItemId);
            }

            return Ok();
        }
    }
}
