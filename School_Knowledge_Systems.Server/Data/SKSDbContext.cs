using Microsoft.EntityFrameworkCore;
using School_Knowledge_Systems.Server.Models;

namespace School_Knowledge_Systems.Server.Data
{
    public class SKSDbContext : DbContext
    {
        public SKSDbContext(DbContextOptions<SKSDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //composite key sectionSubject
            modelBuilder.Entity<SectionSubject>().HasKey(x => new { x.SubjectID, x.SectionID });
        }

        public DbSet<Level> Levels { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SectionSubject> SectionSubjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
