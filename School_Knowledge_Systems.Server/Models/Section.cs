using System.ComponentModel.DataAnnotations;

namespace School_Knowledge_Systems.Server.Models
{
    public class Section
    {
        [Key]
        public string SectionID { get; set; }
        public int StudentCount { get; set; }
        public int NoOfClassesPerWeek { get; set; }
        public List<Student> Students { get; set; }
        public List<SectionSubject> Subjects { get; set; }
        public Level Class { get; set; }

        public Section()
        {
            SectionID = string.Empty;
            Students = new List<Student>();
            Subjects = new List<SectionSubject>();
            Class = new Level();
        }
    }
}
