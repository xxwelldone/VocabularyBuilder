using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyBuilder.Domain.Entities
{
    public class Vocabulary : BaseEntity
    {
        public string Word { get; set; }
        public string Meaning { get; set; }
        public string Audio {  get; set; }
        public Book book { get; set; }
        public int BookId { get; set; }
    }
}
