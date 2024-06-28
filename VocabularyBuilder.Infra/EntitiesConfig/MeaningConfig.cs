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
    public class MeaningConfig : IEntityTypeConfiguration<Meaning>
    {
        public void Configure(EntityTypeBuilder<Meaning> builder)
        {
           
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.word).WithMany(x=>x.meanings).HasForeignKey(x=>x.VocabularyId);
        }
    }
}
