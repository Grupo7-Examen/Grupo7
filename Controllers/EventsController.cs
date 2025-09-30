using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Data;
using TestAPI.Models;

namespace TestAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly AppDbContext _context;

    public EventsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/events
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
        return await _context.Events.AsNoTracking().ToListAsync();
    }

    // GET: api/events/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
        var ev = await _context.Events.FindAsync(id);

        if (ev == null)
        {
            return NotFound();
        }

        return ev;
    }

    // POST: api/events
    [HttpPost]
    public async Task<ActionResult<Event>> PostEvent(Event ev)
    {
        // (Opcional) validación simple de rango de fechas
        if (ev.EndAt.HasValue && ev.EndAt < ev.StartAt)
        {
            return BadRequest("EndAt no puede ser menor que StartAt.");
        }

        _context.Events.Add(ev);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEvent), new { id = ev.Id }, ev);
    }

    // PUT: api/events/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEvent(int id, Event ev)
    {
        if (id != ev.Id)
        {
            return BadRequest();
        }

        if (ev.EndAt.HasValue && ev.EndAt < ev.StartAt)
        {
            return BadRequest("EndAt no puede ser menor que StartAt.");
        }

        _context.Entry(ev).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EventExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/events/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var ev = await _context.Events.FindAsync(id);
        if (ev == null)
        {
            return NotFound();
        }

        _context.Events.Remove(ev);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EventExists(int id)
    {
        return _context.Events.Any(e => e.Id == id);
    }
}
