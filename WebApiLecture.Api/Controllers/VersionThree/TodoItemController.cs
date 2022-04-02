using Microsoft.AspNetCore.Mvc;
using WebApiLecture.Domain.Models;
using WebApiLecture.Domain.Repositories.Interfaces;

namespace WebApiLecture.Api.Controllers.VersionThree
{
    [ApiController]
    [Route("v3/[controller]")]
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
            var todoItems = _todoItemRepository.GetAllResponse();

            return Ok(todoItems);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todoItem = _todoItemRepository.GetDetailById(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        [HttpPost("{todoId}")]
        public IActionResult AddTodoItem(int todoId, TodoItemModel todoItem)
        {
            var isSuccessful = _todoItemRepository.AddTodoItem(todoId, todoItem);

            if (!isSuccessful)
            {
                return NotFound(todoId);
            }

            return Ok(todoItem);
        }

        [HttpPut("{todoItemId}")]
        public IActionResult EditTodoItem(int todoItemId, TodoItemModel model)
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
            var todoItem = _todoItemRepository.EditIsDoneResponse(todoItemId, isDone);

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
