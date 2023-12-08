using Microsoft.EntityFrameworkCore;
using School_Knowledge_Systems.Server.Data;
using School_Knowledge_Systems.Server.Models.DTOs;
using School_Knowledge_Systems.Server.Models.Interfaces;

namespace School_Knowledge_Systems.Server.Models.Services
{
    public class LevelsService : ILevels
    {
        private readonly SKSDbContext _context;

        public LevelsService(SKSDbContext context)
        {
            _context = context;
        }

        public async Task<LevelsDTO> DeleteLevel(string id)
        {
            if (_context.Levels == null)
            {
                return null;
            }
            var level = await _context.Levels.FindAsync(id);
            if (level == null)
            {
                return null;
            }

            _context.Levels.Remove(level);
            await _context.SaveChangesAsync();

            return (LevelsDTO)level;
        }

        public async Task<LevelsDTO> GetLevel(string levelId)
        {
            if (_context.Levels == null)
            {
                return null;
            }
            var level = await _context.Levels.FindAsync(levelId);

            return (LevelsDTO)level;
        }

        public async Task<IEnumerable<LevelsDTO>> GetLevels()
        {
            if (_context.Levels == null)
            {
                return null;
            }
            var levelsList = await _context.Levels.ToListAsync();
            IEnumerable<LevelsDTO> IEnumLevels = levelsList.Select(level => (LevelsDTO)level);
            return IEnumLevels;
        }

        public async Task<bool?> LevelExists(string id)
        {
            var exists = _context.Levels?.Any(e => e.ClassID == id);
            return exists;
        }

        public async Task<LevelsDTO> PostLevel(LevelsDTO level)
        {
            _context.Levels.Add((Level)level);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (await LevelExists(level.ClassID) == false)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return level;
        }

        public async Task<LevelsDTO> PutLevel(string id, LevelsDTOUpdate level)
        {
            var currentLevel = await _context.Levels.FindAsync(id);

            currentLevel.AssignedStudents = level.AssignedStudents;
            currentLevel.UnAssignedStudents = level.UnAssignedStudents;

            _context.Entry(currentLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await LevelExists(id) == false)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return (LevelsDTO)currentLevel;
        }
    }
}
