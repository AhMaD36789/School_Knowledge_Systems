using System.ComponentModel.DataAnnotations;

namespace School_Knowledge_Systems.Server.Models
{
    public class Subject
    {
        [Key]
        public string SubjectID { get; set; }
        public int NoOfClassesPerWeek { get; set; }
        public string ClassID { get; set; }
        public Level Class { get; set; }
        public List<SectionSubject> Sections { get; set; }
        public Teacher Teacher { get; set; }
        public Subject()
        {
            SubjectID = string.Empty;
            ClassID = string.Empty;
            Class = new Level();
            Sections = new List<SectionSubject>();
        }
    }
}
