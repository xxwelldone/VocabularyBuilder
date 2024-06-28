
using Microsoft.EntityFrameworkCore;
using VocabularyBuilder.Domain.Entities;


namespace VocabularyBuilder.Infra.Context
{
    public class PostgreeSQL : DbContext
    {
        public PostgreeSQL(DbContextOptions<PostgreeSQL> opt) : base(opt)
        {

        }
        public DbSet<Vocabulary> vocabularies { get; set;}
        public DbSet<Book> books { get; set;}
        public DbSet<Meaning> meanings { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgreeSQL).Assembly);
        }
    }
}
