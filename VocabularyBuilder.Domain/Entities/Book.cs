using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyBuilder.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public DateTime Date {  get; set; }
        public IEnumerable<Vocabulary> vocabularies { get; set; }
    }
}
