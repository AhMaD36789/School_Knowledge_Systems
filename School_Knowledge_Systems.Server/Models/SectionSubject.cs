namespace School_Knowledge_Systems.Server.Models
{
    public class SectionSubject
    {
        public string SectionID { get; set; }
        public string SubjectID { get; set; }
        public Section Section { get; set; }
        public Subject Subject { get; set; }

        public SectionSubject()
        {
            SectionID = string.Empty;
            SubjectID = string.Empty;
            Subject = new Subject();
            Section = new Section();
        }
    }
}
