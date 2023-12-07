using School_Knowledge_Systems.Server.Models.DTOs;

namespace School_Knowledge_Systems.Server.Models.Interfaces
{
    public interface ILevels
    {
        Task<IEnumerable<LevelsDTO>> GetLevels();
        Task<LevelsDTO> GetLevel(string levelId);
        Task<LevelsDTO> PutLevel(string id, LevelsDTO level);
        Task<LevelsDTO> PostLevel(LevelsDTO level);
        Task<LevelsDTO> DeleteLevel(string id);
        Task<bool> LevelExists(string id);
    }
}
