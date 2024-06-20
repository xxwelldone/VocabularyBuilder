using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
