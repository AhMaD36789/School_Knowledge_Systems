using System.ComponentModel.DataAnnotations;

namespace School_Knowledge_Systems.Server.Models
{
    public class Student
    {
        [Key]
        public string Name { get; set; }
        public int FatherPhoneNumber { get; set; }
        public string ClassID { get; set; }
        public Level Class { get; set; }
        public string SectionID { get; set; }
        public Section Section { get; set; }

        public Student()
        {
            Name = string.Empty;
            Class = new Level();
            Section = new Section();
            ClassID = string.Empty;
            SectionID = string.Empty;
        }
    }
}
