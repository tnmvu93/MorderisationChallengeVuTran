using Microsoft.EntityFrameworkCore;

namespace MorderisationChallengeVT.Persistence
{
    public class MorderisationChallengeDbContext : DbContext
    {
        public MorderisationChallengeDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateTasks(modelBuilder);
        }

        private void CreateTasks(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Domain.Entities.Task>().ToTable("Tasks");
            entity.HasKey(x => x.Id);
            entity.HasQueryFilter(x => !x.DateDeleted.HasValue);
            entity.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            entity.Property(x => x.DateCreated).IsRequired();
            entity.Property(x => x.DateModified).IsRequired();
            entity.Property(x => x.DateDeleted).IsRequired(false);
            entity.Property(x => x.Completed).IsRequired();
            entity.Property(x => x.Details).IsRequired();
        }
    }
}
