using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VocabularyBuilder.Domain.Entities;

namespace VocabularyBuilder.Infra.EntitiesConfig
{
    public class VocabularyConfig : IEntityTypeConfiguration<Vocabulary>
    {
        public void Configure(EntityTypeBuilder<Vocabulary> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Word).IsRequired();
            builder.HasOne(b=>b.book).WithMany(v=>v.vocabularies).HasForeignKey(i => i.BookId);
        }
    }
}
