using Microsoft.AspNetCore.Mvc;
using AcademyManagement.Data;
using AcademyManagement.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AcademyController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AcademyController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/academy
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Academy>>> GetAcademies()
    {
        return await _context.Academies.ToListAsync();
    }

    // POST: api/academy
    [HttpPost]
    public async Task<IActionResult> AddAcademy([FromBody] Academy academy)
    {
        if (academy == null)
        {
            return BadRequest("Invalid academy data.");
        }

        _context.Academies.Add(academy);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAcademies), new { id = academy.Id }, academy);
    }
}
