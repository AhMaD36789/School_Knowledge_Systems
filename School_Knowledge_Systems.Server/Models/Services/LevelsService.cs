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

        public Task<LevelsDTO> GetLevel(string levelId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LevelsDTO>> GetLevels()
        {
            if (_context.Levels == null)
            {
                return null;
            }
            return (IEnumerable<LevelsDTO>)await _context.Levels.ToListAsync();
        }

        public Task<bool> LevelExists(string id)
        {
            throw new NotImplementedException();
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
                if (await LevelExists(level.ClassID))
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

        public Task<LevelsDTO> PutLevel(string id, LevelsDTO level)
        {
            throw new NotImplementedException();
        }
    }
}
