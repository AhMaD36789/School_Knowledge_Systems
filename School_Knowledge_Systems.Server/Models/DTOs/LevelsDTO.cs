namespace School_Knowledge_Systems.Server.Models.DTOs
{
    public class LevelsDTO
    {
        public string ClassID { get; set; }
        public int AssignedStudents { get; set; }
        public int UnAssignedStudents { get; set; }

        public LevelsDTO()
        {
            ClassID = string.Empty;
        }

        public static explicit operator LevelsDTO(Level level)
        {
            return new LevelsDTO
            {
                ClassID = level.ClassID,
                AssignedStudents = level.AssignedStudents,
                UnAssignedStudents = level.UnAssignedStudents
            };
        }

        public static explicit operator Level(LevelsDTO levelsDTO)
        {
            return new Level
            {
                ClassID = levelsDTO.ClassID,
                AssignedStudents = levelsDTO.AssignedStudents,
                UnAssignedStudents = levelsDTO.UnAssignedStudents
            };
        }
    }
    public class LevelsDTOUpdate
    {
        public int AssignedStudents { get; set; }
        public int UnAssignedStudents { get; set; }

    }

}
