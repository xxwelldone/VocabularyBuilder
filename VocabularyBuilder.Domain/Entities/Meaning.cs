using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyBuilder.Domain.Entities
{
    public class Meaning : BaseEntity
    {
        public Vocabulary word { get; set; }
        public int VocabularyId { get; set; }
        public string PartOfSpeech { get; set; }
        public string Definitions { get; set; }
        public string Example { get; set; }
    }
}
