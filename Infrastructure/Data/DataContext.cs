using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public  class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserTest> UserTests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>().HasKey(ug => new { ug.UserId, ug.GroupId });
            modelBuilder.Entity<UserTest>().HasKey(ut => new { ut.UserId, ut.TestId });
            base.OnModelCreating(modelBuilder);
        }

    }
}
