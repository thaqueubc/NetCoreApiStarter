using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiStarter.Models;

namespace NetCoreApiStarter.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _context.ToDos.ToList();
            if (items == null || items.Count <= 0)
            {
                return NotFound();
            }
            return new ObjectResult(items);

        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.ToDos.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "description": "Item1",
        ///        "isComplete": true,
        ///        "priority": 1,
        ///        "createdOn": "2020-01-01T00:00:00.0000001"
        ///     }
        /// </remarks> 
        /// /// <returns>A newly created Todo Item</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is not saved</response>

        /// <param name="todo"></param>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Create(ToDo todo)
        {
            try
            {
                _context.ToDos.Add(todo);
                _context.SaveChanges();
                // This allows for a status code of 201 (Created)
                return new CreatedAtRouteResult("", new { id = todo.Id }, todo);
            }
            catch (Exception e)
            {
                //Bad Request status code 400
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("MyEdit")] // Custom route
        public IActionResult GetByParams([FromBody]ToDo todo)
        {
            var item = _context.ToDos.Where(t => t.Id == todo.Id).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                item.IsComplete = todo.IsComplete;
                _context.SaveChanges();
            }
            return new ObjectResult(item);
        }

        /// <summary>
        /// Deletes a specific Project.
        /// </summary> 
        /// <param name="id"></param>


        [HttpDelete]
        [Route("MyDelete")] // Custom route
        public IActionResult MyDelete(long id)
        {
            var item = _context.ToDos.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            _context.ToDos.Remove(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }
    }
}