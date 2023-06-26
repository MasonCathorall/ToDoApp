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

        //Get todo by id
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetToDo(Guid id)
        {
            return await _context.Todos.Where(x => x.Id == id).ToListAsync();
        }

        //post flashcard
        [HttpPost]
        public async Task<ActionResult<ToDo>> PostToDo(ToDo c)
        {
            c.Id = Guid.Empty;
            _context.Todos.Add(c);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostToDo", new { id = c.Id }, c);
        }

        //delete flashcard
        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDo>> DeleteToDo(Guid id)
        {
            var card = await _context.Todos.FindAsync(id);


            if (card is null)
                return NotFound();

            _context.Todos.Remove(card);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //update flashcard
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDo(Guid id, ToDo card)
        {
            _context.Entry(card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Todos.Any(e => e.Id == id))
                    return NotFound();
                else throw;
            }

            return NoContent();
        }
    }
}
