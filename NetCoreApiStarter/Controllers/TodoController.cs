using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiStarter.Models;

namespace NetCoreApiStarter.Controllers
{
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

        [HttpPost]
        public IActionResult Create(ToDo todo)
        {
            try
            {
                _context.ToDos.Add(todo);
                _context.SaveChanges();
                // This allows for a status code of 201 (Created)
                return new ObjectResult(todo);
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