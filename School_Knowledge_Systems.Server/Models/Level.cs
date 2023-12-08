using System.ComponentModel.DataAnnotations;

namespace School_Knowledge_Systems.Server.Models
{
    public class Level
    {
        [Key]
        public string ClassID { get; set; }
        public int AssignedStudents { get; set; }
        public int UnAssignedStudents { get; set; }
        public IEnumerable<Section> Sections { get; set; }

        public Level()
        {
            ClassID = string.Empty;
            Sections = new List<Section>();
        }
    }
}
