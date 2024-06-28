using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabularyBuilder.Domain.Entities;
using VocabularyBuilder.Domain.Interface;
using VocabularyBuilder.Infra.Context;

namespace VocabularyBuilder.Infra.Repositories
{
    public class MeaningRepository : BaseRepository<Meaning>, IMeaningRepository
    {
        public MeaningRepository(PostgreeSQL context) : base(context)
        {
        }
    }
}
