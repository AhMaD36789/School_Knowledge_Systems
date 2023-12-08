﻿using Microsoft.AspNetCore.Mvc;
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
            var Level = await _levels.GetLevel(id);
            return Level != null ? Ok(Level) : NotFound();

        }

        // PUT: api/Levels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLevel(string id, LevelsDTOUpdate level)
        {
            var updatedLevel = await _levels.PutLevel(id, level);
            return updatedLevel != null ? Ok(updatedLevel) : NotFound();
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
    }
}
