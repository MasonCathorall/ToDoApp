using ToDoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context)
        {
            this._context = context;
        }

        //Get all todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetAllToDos()
        {
            return await _context.Todos.ToListAsync();
        }
    }
}
