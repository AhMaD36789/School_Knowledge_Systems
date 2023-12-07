using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Knowledge_Systems.Server.Data;
using School_Knowledge_Systems.Server.Models;
using School_Knowledge_Systems.Server.Models.DTOs;
using School_Knowledge_Systems.Server.Models.Interfaces;

namespace School_Knowledge_Systems.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly SKSDbContext _context;
        private readonly ILevels _levels;

        public LevelsController(SKSDbContext context, ILevels levels)
        {
            _context = context;
            _levels = levels;
        }

        // GET: api/Levels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Level>>> GetLevels()
        {
            var LevelsList = await _levels.GetLevels();
            return LevelsList != null ? Ok(LevelsList) : NotFound();
        }

        // GET: api/Levels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Level>> GetLevel(string id)
        {
            if (_context.Levels == null)
            {
                return NotFound();
            }
            var level = await _context.Levels.FindAsync(id);

            if (level == null)
            {
                return NotFound();
            }

            return level;
        }

        // PUT: api/Levels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLevel(string id, Level level)
        {
            if (id != level.ClassID)
            {
                return BadRequest();
            }

            _context.Entry(level).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelExists(id))
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

        // POST: api/Levels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LevelsDTO>> PostLevel(LevelsDTO level)
        {
            var createdLevel = await _levels.PostLevel(level);

            return CreatedAtAction("GetLevel", new { id = level.ClassID }, createdLevel);
        }

        // DELETE: api/Levels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLevel(string id)
        {
            var categories = await _levels.DeleteLevel(id);
            return categories != null ? Ok(categories) : NotFound();
        }

        private bool LevelExists(string id)
        {
            return (_context.Levels?.Any(e => e.ClassID == id)).GetValueOrDefault();
        }
    }
}
